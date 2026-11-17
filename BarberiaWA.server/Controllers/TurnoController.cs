using BarberiaWA.BD.Datos.Entity;
using BarberiaWA.Shared.DTO;
using BarberiaWA.Repositorio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberiaWA.server.Controllers
{
    [ApiController]
    [Route("api/turno")]
    public class TurnoController : ControllerBase
    {
        private readonly ITurnoRepositorio repositorio;
        private readonly IServicioRepositorio servicioRepositorio;

        public TurnoController(
            ITurnoRepositorio repositorio,
            IServicioRepositorio servicioRepositorio)
        {
            this.repositorio = repositorio;
            this.servicioRepositorio = servicioRepositorio;
        }

        // GET: api/turno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TurnoDTO>>> Get()
        {
            var turnos = await repositorio.Select();

            var resultado = turnos.Select(t => new TurnoDTO
            {
                Id = t.Id,
                FechaHora = t.FechaHora,
                Estado = t.Estado,
                ClienteId = t.ClienteId,
                ServicioId = t.ServicioId
            });

            return Ok(resultado);
        }

        // GET: api/turno/1
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TurnoDTO>> GetById(int id)
        {
            var entidad = await repositorio.SelectById(id);

            if (entidad is null)
            {
                return NotFound($"No existe el turno con id: {id}.");
            }

            var dto = new TurnoDTO
            {
                Id = entidad.Id,
                FechaHora = entidad.FechaHora,
                Estado = entidad.Estado,
                ClienteId = entidad.ClienteId,
                ServicioId = entidad.ServicioId
            };

            return Ok(dto);
        }

        // POST: api/turno
        [HttpPost]
        public async Task<ActionResult<int>> Post(TurnoDTO dto)
        {
            var servicio = await servicioRepositorio.SelectById(dto.ServicioId);

            if (servicio is null)
            {
                return NotFound(
                    $"No existe el servicio con ID: {dto.ServicioId}.");
            }

            if (servicio.DuracionMinutos <= 0)
            {
                return BadRequest("La duración del servicio no es válida.");
            }

            bool horarioOcupado = await repositorio.ExisteSuperposicion(
                dto.FechaHora,
                servicio.DuracionMinutos);

            if (horarioOcupado)
            {
                return Conflict(
                    "El horario seleccionado ya está ocupado. Elegí otro horario.");
            }

            var entidad = new Turno
            {
                FechaHora = dto.FechaHora,
                Estado = dto.Estado,
                ClienteId = dto.ClienteId,
                ServicioId = dto.ServicioId
            };

            var turnoId = await repositorio.CrearSiDisponibleAsync(
                entidad,
                servicio.DuracionMinutos);

            if (!turnoId.HasValue)
            {
                return Conflict(
                    "El horario seleccionado ya está ocupado. Elegí otro horario.");
            }

            return Ok(turnoId.Value);
        }

        // PUT: api/turno/1
        [HttpPut("{id:int}")]
        public async Task<ActionResult<bool>> Put(int id, TurnoDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest(
                    "El ID de la URL no coincide con el ID del DTO.");
            }

            var entidadActual = await repositorio.SelectById(id);

            if (entidadActual is null)
            {
                return NotFound($"No existe el turno con ID: {id}.");
            }

            var servicio = await servicioRepositorio.SelectById(dto.ServicioId);

            if (servicio is null)
            {
                return NotFound(
                    $"No existe el servicio con ID: {dto.ServicioId}.");
            }

            if (servicio.DuracionMinutos <= 0)
            {
                return BadRequest("La duración del servicio no es válida.");
            }

            bool esCancelado = dto.Estado == "Cancelado";
            bool esRealizado = dto.Estado == "Realizado";

            // Se valida la disponibilidad cuando el turno sigue ocupando
            // un horario, por ejemplo, al reprogramarlo.
            if (!esCancelado && !esRealizado)
            {
                bool horarioOcupado = await repositorio.ExisteSuperposicion(
                    dto.FechaHora,
                    servicio.DuracionMinutos,
                    id);

                if (horarioOcupado)
                {
                    return Conflict(
                        "El horario seleccionado ya está ocupado. Elegí otro horario.");
                }
            }

            var entidad = new Turno
            {
                Id = id,
                FechaHora = dto.FechaHora,
                Estado = dto.Estado,
                ClienteId = dto.ClienteId,
                ServicioId = dto.ServicioId
            };

            var actualizado = await repositorio.Update(entidad);

            if (!actualizado)
            {
                return NotFound($"No existe el turno con ID: {id}.");
            }

            return Ok(true);
        }

        // DELETE: api/turno/1
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var eliminado = await repositorio.Delete(id);

            if (!eliminado)
            {
                return NotFound($"No existe el turno con ID: {id}.");
            }

            return Ok(true);
        }
    }
}