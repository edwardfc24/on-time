using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.Models
{
    public class HTEmpleado
    {
        public int pkHTEmpleado { get; set; }
        public int fkHoTurno { get; set; }
        public int fkEmpleado { get; set; }
    }
}