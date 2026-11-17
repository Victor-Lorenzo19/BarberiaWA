using BarberiaWA.BD.Datos;
using BarberiaWA.BD.Datos.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberiaWA.Repositorio.Repositorios
{
    public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
    {
        private readonly AppDbcontext _context;

        public ClienteRepositorio(AppDbcontext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> SelectByNombre(string nombre)
        {
            var consulta = _context.Set<Cliente>()
                .Where(c => c.Nombre.Contains(nombre));

            return await consulta.ToListAsync();
        }
    }
}