using BarberiaWA.BD.Datos.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberiaWA.Repositorio.Repositorios
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        Task<List<Cliente>> SelectByNombre(string nombre);
    }
}