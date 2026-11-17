using BarberiaWA.Shared.DTO;
using BarberiaWA.Repositorio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServicioEntidad = BarberiaWA.BD.Datos.Entity.Servicio;

namespace BarberiaWA.server.Controllers
{
    [ApiController]
    [Route("api/servicio")]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioRepositorio repositorio;

        public ServicioController(IServicioRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        // GET: api/servicio/1
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServicioDTO>> GetById(int id)
        {
            var entidad = await repositorio.SelectById(id);

            if (entidad is null)
            {
                return NotFound($"No existe el servicio con id: {id}.");
            }

            var dto = new ServicioDTO
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre,
                Precio = entidad.Precio,
                DuracionMinutos = entidad.DuracionMinutos
            };

            return Ok(dto);
        }

        // GET: api/servicio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicioDTO>>> Get()
        {
            var servicios = await repositorio.Select();

            var lista = servicios.Select(s => new ServicioDTO
            {
                Id = s.Id,
                Nombre = s.Nombre,
                Precio = s.Precio,
                DuracionMinutos = s.DuracionMinutos
            });

            return Ok(lista);
        }

        // POST: api/servicio
        [HttpPost]
        public async Task<ActionResult<int>> Post(ServicioDTO dto)
        {
            var entidad = new ServicioEntidad
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                DuracionMinutos = dto.DuracionMinutos
            };

            var servicioCreado = await repositorio.Insert(entidad);

            return Ok(servicioCreado.Id);
        }

        // PUT: api/servicio/1
        [HttpPut("{id:int}")]
        public async Task<ActionResult<bool>> Put(int id, ServicioDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest(
                    "El ID de la URL no coincide con el ID del DTO.");
            }

            var entidad = new ServicioEntidad
            {
                Id = id,
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                DuracionMinutos = dto.DuracionMinutos
            };

            var actualizado = await repositorio.Update(entidad);

            if (!actualizado)
            {
                return NotFound($"No existe el servicio con ID: {id}.");
            }

            return Ok(true);
        }

        // DELETE: api/servicio/1
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var eliminado = await repositorio.Delete(id);

            if (!eliminado)
            {
                return NotFound($"No existe el servicio con ID: {id}.");
            }

            return Ok(true);
        }
    }
}