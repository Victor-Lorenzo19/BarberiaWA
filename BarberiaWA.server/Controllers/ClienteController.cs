
using BarberiaWA.Shared.DTO;
using BarberiaWA.Repositorio.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClienteEntidad = BarberiaWA.BD.Datos.Entity.Cliente;

namespace BarberiaWA.server.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio repositorio;
        private readonly ITurnoRepositorio turnoRepositorio;

        public ClienteController(
            IClienteRepositorio repositorio,
            ITurnoRepositorio turnoRepositorio)
        {
            this.repositorio = repositorio;
            this.turnoRepositorio = turnoRepositorio;
        }

        // GET: api/cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
            var lista = await repositorio.Select();

            var resultado = lista.Select(c => new ClienteDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                Telefono = c.Telefono,
                Email = c.Email
            });

            return Ok(resultado);
        }

        // GET: api/cliente/1
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClienteDTO>> GetById(int id)
        {
            var entidad = await repositorio.SelectById(id);

            if (entidad is null)
            {
                return NotFound($"No existe el cliente con id: {id}.");
            }

            var dto = new ClienteDTO
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre,
                Apellido = entidad.Apellido,
                Telefono = entidad.Telefono,
                Email = entidad.Email
            };

            return Ok(dto);
        }

        // GET: api/cliente/1/historial
        [HttpGet("{id:int}/historial")]
        public async Task<ActionResult<IEnumerable<TurnoDTO>>> GetHistorial(int id)
        {
            var cliente = await repositorio.SelectById(id);

            if (cliente is null)
            {
                return NotFound($"No existe el cliente con ID: {id}.");
            }

            var turnos = await turnoRepositorio.Select();

            var historial = turnos
                .Where(t =>
                    t.ClienteId == id &&
                    string.Equals(
                        t.Estado,
                        "Realizado",
                        StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(t => t.FechaHora)
                .Select(t => new TurnoDTO
                {
                    Id = t.Id,
                    FechaHora = t.FechaHora,
                    Estado = t.Estado,
                    ClienteId = t.ClienteId,
                    ServicioId = t.ServicioId
                })
                .ToList();

            return Ok(historial);
        }

        // POST: api/cliente
        [HttpPost]
        public async Task<ActionResult<int>> Post(ClienteDTO dto)
        {
            var entidad = new ClienteEntidad
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Telefono = dto.Telefono,
                Email = dto.Email
            };

            var clienteCreado = await repositorio.Insert(entidad);

            return Ok(clienteCreado.Id);
        }

        // PUT: api/cliente/1
        [HttpPut("{id:int}")]
        public async Task<ActionResult<bool>> Put(int id, ClienteDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest(
                    "El ID de la URL no coincide con el ID del DTO.");
            }

            var entidad = new ClienteEntidad
            {
                Id = id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Telefono = dto.Telefono,
                Email = dto.Email
            };

            var actualizado = await repositorio.Update(entidad);

            if (!actualizado)
            {
                return NotFound($"No existe el cliente con ID: {id}.");
            }

            return Ok(true);
        }

        // DELETE: api/cliente/1
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var eliminado = await repositorio.Delete(id);

            if (!eliminado)
            {
                return NotFound($"No existe el cliente con ID: {id}.");
            }

            return Ok(true);
        }
    }
}
