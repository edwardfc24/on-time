using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.Models
{
    public class Vacacion
    {
        public int pkVacacion { get; set; }
        public DateTime dateFechaInicio { get; set; }
        public DateTime dateFechaFin { get; set; }
        public int fkEmpleado { get; set; }
        public int fkAutorizacion { get; set; }
    }
}