using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.Models
{
    public class EmpPermiso
    {
        public int pkEmpPermiso { get; set; }
        public DateTime dateFechaInicio { get; set; }
        public DateTime dateFechafin { get; set; }
        public string tHoraInicio { get; set; }
        public string tHoraFin { get; set; }
        public int fkEmpleado { get; set; }
        public int fkPermiso { get; set; }
    }
}