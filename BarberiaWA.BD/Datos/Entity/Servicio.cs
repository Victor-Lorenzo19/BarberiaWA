using System;
using System.Collections.Generic;
using System.Text;

namespace BarberiaWA.BD.Datos.Entity
{
    public class Servicio : EntityBase
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int DuracionMinutos { get; set; }
    }
}
