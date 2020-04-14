using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaMVC.Models
{
    public class Empleados
    {
        private int pkEmpleado;

        public int PkEmpleado
        {
            get { return pkEmpleado; }
            set { pkEmpleado = value; }
        }

        private string txtNombre;

        public string TxtNombre
        {
            get { return txtNombre; }
            set { txtNombre = value; }
        }

        private string txtApellidos;

        public string TxtApellidos
        {
            get { return txtApellidos; }
            set { txtApellidos = value; }
        }

        private string txtCI;

        public string TxtCI
        {
            get { return txtCI; }
            set { txtCI = value; }
        }

        private DateTime dateFechaNacimiento;

        public DateTime DateFechaNacimiento
        {
            get { return dateFechaNacimiento; }
            set { dateFechaNacimiento = value; }
        }

        private string txtPassword;

        public string TxtPassword
        {
            get { return txtPassword; }
            set { txtPassword = value; }
        }

        private string txtDireccion;

        public string TxtDireccion
        {
            get { return txtDireccion; }
            set { txtDireccion = value; }
        }

        private string txtTelefono;

        public string TxtTelefono
        {
            get { return txtTelefono; }
            set { txtTelefono = value; }
        }

        private string txtCorreo;

        public string TxtCorreo
        {
            get { return txtCorreo; }
            set { txtCorreo = value; }
        }

        private DateTime dateFechaContrato;

        public DateTime DateFechaContrato
        {
            get { return dateFechaContrato; }
            set { dateFechaContrato = value; }
        }

        private int intFlagEstado;

        public int IntFlagEstado
        {
            get { return intFlagEstado; }
            set { intFlagEstado = value; }
        }

        private int intTipo;

        public int IntTipo
        {
            get { return intTipo; }
            set { intTipo = value; }
        }

        public Empleados()
        { }
        
    }
}