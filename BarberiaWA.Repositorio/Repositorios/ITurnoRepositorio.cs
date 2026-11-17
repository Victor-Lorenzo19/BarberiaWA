
using BarberiaWA.BD.Datos.Entity;
using System;
using System.Threading.Tasks;

namespace BarberiaWA.Repositorio.Repositorios
{
    // Interfaz específica para trabajar con los turnos.
    // Hereda las operaciones CRUD de IRepositorio<Turno>.
    public interface ITurnoRepositorio : IRepositorio<Turno>
    {
        // Comprueba si existe otro turno que se superponga
        // con la fecha y duración que queremos reservar.
        Task<bool> ExisteSuperposicion(
            DateTime fechaHora,
            int duracionMinutos,
            int? turnoIdExcluir = null);

        // Crea un turno únicamente si el horario está disponible.
        // La comprobación y el guardado se realizarán dentro
        // de una misma transacción.
        Task<int?> CrearSiDisponibleAsync(
            Turno turno,
            int duracionMinutos);
    }
}
