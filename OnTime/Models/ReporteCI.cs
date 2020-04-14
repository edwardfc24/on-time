using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.Models
{
    public class ReporteCI
    {
        public string Empleado { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraEntradaActual { get; set; }
        public int DiferenciaEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public TimeSpan HoraSalidaActual { get; set; }
        public int DiferenciaSalida { get; set; }
        public DateTime Fecha { get; set; }
        public string CarnetIdentidad { get; set; }
        public string Horario { get; set; }
    }
}