using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BarberiaWA.BD.Datos.Entity
{
    public class Cliente : EntityBase
    {
       
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }


    }
}
