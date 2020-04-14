using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.Models
{
    public class Mensaje
    {
        public int pkMensaje { get; set; }
        public string txtDescripcion { get; set; }
        public int fkRemitente { get; set; }
    }
}