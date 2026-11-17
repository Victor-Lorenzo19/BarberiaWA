using BarberiaWA.BD.Datos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberiaWA.Repositorio.Repositorios
{
    public interface IRepositorio<E> where E : EntityBase
    {
        Task<bool> Existe(E entidad);

        Task<List<E>> Select();

        Task<E?> SelectById(int id);

        Task<E> Insert(E entidad);

        Task<bool> Update(E entidad);

        Task<bool> Delete(int id);
    }
}