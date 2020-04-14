using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnTime.Models
{
    public class Empleado
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es requerido.")]
        public int pkEmpleado { get; set; }
        
        public string txtNombre { get; set; }
        [Required(ErrorMessage = "Los apellidos son requeridos.")]
        [Display(Name = "Apellidos")]
        public string txtApellidos { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(8, ErrorMessage = "El C.I. no puede exceder los 8 caracteres")]
        [Display(Name = "C.I.")]
        public string txtCI { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime dateFechaNacimiento { get; set; }
        [Display(Name = "Contraseña")]
        public string txtPassword { get; set; }
        [Display(Name = "Dirección")]
        public string txtDireccion { get; set; }
        [Display(Name = "Teléfono")]
        public string txtTelefono { get; set; }
        [Display(Name = "Email")]
        public string txtCorreo { get; set; }
        [Display(Name = "Fecha de Contrato")]
        public DateTime dateFechaContrato { get; set; }
        [Display(Name = "Estado")]
        public int intFlagEstado { get; set; }
        [Display(Name = "Tipo de Empleado")]
        public int intTipo { get; set; }
        public string fullName { get; set; }
    }
}