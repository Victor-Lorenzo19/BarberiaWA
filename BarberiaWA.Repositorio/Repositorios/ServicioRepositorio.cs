using BarberiaWA.BD.Datos;
using BarberiaWA.BD.Datos.Entity;

namespace BarberiaWA.Repositorio.Repositorios
{
    public class ServicioRepositorio : Repositorio<Servicio>, IServicioRepositorio
    {
        public ServicioRepositorio(AppDbcontext context)
            : base(context)
        {
        }
    }
}