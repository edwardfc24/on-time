using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.Models
{
    public class EmpCargo
    {
        public int pkEmpCargo { get; set; }
        public int fkEmpleado { get; set; }
        public int fkCargo { get; set; }
    }
}