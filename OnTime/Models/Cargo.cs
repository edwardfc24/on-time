using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnTime.Models
{
    public class Cargo
    {
        public int pkCargo { get; set; }
        public string txtNombre { get; set; }
        public int fkDepartamento { get; set; }
    }
}