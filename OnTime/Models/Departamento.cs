using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.Models
{
    public class Departamento
    {
        public int pkDepartamento { get; set; }
        public string txtNombre { get; set; }
        public int fkJefe { get; set; }
    }
}