using System;
using System.Collections.Generic;
using System.Text;

namespace BarberiaWA.Shared.DTO
{
    public class ServicioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int DuracionMinutos { get; set; }
    }
}
