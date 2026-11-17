using System;
using System.Collections.Generic;
using System.Text;

namespace BarberiaWA.Shared.DTO
{
    public class TurnoDTO
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; }
        public int ClienteId { get; set; }
        public int ServicioId { get; set; }
    }
}
