
using BarberiaWA.BD.Datos;
using BarberiaWA.BD.Datos.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BarberiaWA.Repositorio.Repositorios
{
    // Repositorio específico de los turnos.
    // Hereda las operaciones generales de Repositorio<Turno>
    // e implementa la interfaz ITurnoRepositorio.
    public class TurnoRepositorio : Repositorio<Turno>, ITurnoRepositorio
    {
        // Contexto utilizado para acceder a la base de datos.
        private readonly AppDbcontext _context;

        // Constructor: recibe el contexto mediante inyección de dependencias.
        // base(context) permite utilizar los métodos CRUD heredados.
        public TurnoRepositorio(AppDbcontext context) : base(context)
        {
            _context = context;
        }

        // Comprueba si existe un turno que se superponga
        // con el horario que se intenta reservar.
        public async Task<bool> ExisteSuperposicion(
            DateTime fechaHora,
            int duracionMinutos,
            int? turnoIdExcluir = null)
        {
            // Calcula el horario de finalización del nuevo turno.
            DateTime nuevoInicio = fechaHora;
            DateTime nuevoFin = fechaHora.AddMinutes(duracionMinutos);

            // Consulta los turnos registrados.
            var turnos = _context.Set<Turno>()
                .Include(t => t.Servicio);

            // Busca si algún turno existente se cruza con el nuevo.
            return await turnos.AnyAsync(t =>

                // Excluye el turno actual cuando se está modificando.
                (!turnoIdExcluir.HasValue ||
                 t.Id != turnoIdExcluir.Value)

                // Los turnos cancelados no ocupan horarios.
                && t.Estado != "Cancelado"

                // El turno existente comienza antes de que termine el nuevo.
                && t.FechaHora < nuevoFin

                // El turno existente termina después del inicio del nuevo.
                && t.FechaHora.AddMinutes(
                    t.Servicio.DuracionMinutos) > nuevoInicio
            );
        }

        // Comprueba la disponibilidad y guarda el turno
        // dentro de una misma transacción.
        public async Task<int?> CrearSiDisponibleAsync(
            Turno turno,
            int duracionMinutos)
        {
            // Inicia una transacción con aislamiento Serializable.
            // Este nivel protege la comprobación frente a modificaciones
            // concurrentes de la base de datos.
            await using var transaccion =
                await _context.Database.BeginTransactionAsync(
                    IsolationLevel.Serializable);

            // Comprueba si el horario ya está ocupado.
            bool horarioOcupado = await ExisteSuperposicion(
                turno.FechaHora,
                duracionMinutos);

            // Si está ocupado, cancela la transacción.
            if (horarioOcupado)
            {
                await transaccion.RollbackAsync();

                // null indica que no se pudo crear el turno.
                return null;
            }

            // Si está disponible, agrega el nuevo turno.
            _context.Set<Turno>().Add(turno);

            // Guarda los cambios dentro de la transacción.
            await _context.SaveChangesAsync();

            // Confirma definitivamente la operación.
            await transaccion.CommitAsync();

            // Devuelve el ID generado por la base de datos.
            return turno.Id;
        }
    }
}
