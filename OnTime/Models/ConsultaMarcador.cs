using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnTime.Models
{
    public class ConsultaMarcador
    {
        public string txtNombre { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es requerido.")]
        public string txtNombre1 { get; set; }
        [Required(ErrorMessage = "Los apellidos son requeridos.")]
        [Display(Name = "Apellidos")]
        public string txtNomrbeTurno { get; set; }
        [Display(Name = "C.I.")]
        public TimeSpan tHoraEntrada { get; set; }
        public TimeSpan tHoraSalida { get; set; }
        public string txtDias { get; set; }
    }
}