using System;
using System.Collections.Generic;
using System.Text;



namespace BarberiaWA.BD.Datos.Entity
{
    public class Turno : EntityBase
    {
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; }
    }
}