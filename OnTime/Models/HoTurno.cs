using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.Models
{
    public class HoTurno
    {
        public int pkHoTurno { get; set; }
        public int fkHorario { get; set; }
        public int fkTurno { get; set; }
    }
}