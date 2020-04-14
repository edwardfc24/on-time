using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.Models
{
    public class Horario
    {
        public int pkHorario { get; set; }
        public string txtNombre { get; set; }
        public string tHoraEntrada { get; set; }
        public string tHoraSalida { get; set; }
        public string txtDias { get; set; }
        public int intEstado { get; set; }
    }
}