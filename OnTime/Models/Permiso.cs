using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.Models
{
    public class Permiso
    {
        public int pkPermiso { get; set; }
        public string txtDescripcion { get; set; }
        public int intEstado { get; set; }
    }
}