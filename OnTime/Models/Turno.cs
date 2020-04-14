using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.Models
{
    public class Turno
    {
        public int pkTurno { get; set; }
        public string txtNombre { get; set; }
        public int intEstado { get; set; }
    }
}