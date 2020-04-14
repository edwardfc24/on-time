using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.Models
{
    public class EmpMensaje
    {
        public int pkEmpMensaje { get; set; }
        public int fkMensaje { get; set; }
        public int fkEmpleado { get; set; }
    }
}