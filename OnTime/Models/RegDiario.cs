using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.Models
{
    public class RegDiario
    {
        public int pkRegDiario { get; set; }
        public DateTime dateFechaActual { get; set; }
        public string tHoraEntradaReal { get; set; }
        public string tHoraSalidaReal { get; set; }
        public string tHoraEntrada { get; set; }
        public string tHoraSalida { get; set; }
        public string txtNombreHorario { get; set; }
        public int fkEmpleado { get; set; }
    }
}