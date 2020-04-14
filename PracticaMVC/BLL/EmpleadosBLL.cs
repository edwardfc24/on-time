using PracticaMVC.DAL;
using PracticaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaMVC.BLL
{
    public class EmpleadosBLL
    {
        public EmpleadosBLL()
        {
        }
        public static Empleados rowToDto(EmpleadoDS.EmpleadosRow row)
        {
            Empleados objEmpleado = new Empleados();
            objEmpleado.PkEmpleado = row.pkEmpleado;
            objEmpleado.TxtNombre = row.txtNombre;
            objEmpleado.TxtApellidos = row.txtApellidos;
            objEmpleado.TxtCI = row.txtCI;
            objEmpleado.DateFechaNacimiento = row.dateFechaNacimiento;
            objEmpleado.TxtPassword = System.Text.Encoding.UTF8.GetString(row.txtPassword);
            objEmpleado.TxtDireccion = row.txtDireccion;
            objEmpleado.TxtCorreo = row.txtCorreo;
            objEmpleado.DateFechaContrato = row.dateFechaContrato;
            objEmpleado.IntFlagEstado = row.intFlagEstado;
            objEmpleado.IntTipo = row.intTipo;

            return objEmpleado;
        }
        public static List<Empleados> SelectAll()
        {
            List<Empleados> listadeEmpleados = new List<Empleados>();

            PracticaMVC.DAL.EmpleadoDSTableAdapters.EmpleadosTableAdapter objDataSet = new PracticaMVC.DAL.EmpleadoDSTableAdapters.EmpleadosTableAdapter();
            EmpleadoDS.EmpleadosDataTable dtEmpleado = objDataSet.SelectAll();

            foreach (EmpleadoDS.EmpleadosRow row in dtEmpleado)
            {
                Empleados objEmpleado = rowToDto(row);
                listadeEmpleados.Add(objEmpleado);
            }
            return listadeEmpleados;
        }

        public static Empleados GetById(int pk)
        {
            List<Empleados> listadeEmpleados = new List<Empleados>();

            PracticaMVC.DAL.EmpleadoDSTableAdapters.EmpleadosTableAdapter objDataSet = new PracticaMVC.DAL.EmpleadoDSTableAdapters.EmpleadosTableAdapter();
            EmpleadoDS.EmpleadosDataTable dtEmpleado = objDataSet.GetById(pk);

            Empleados objEmpleado = rowToDto(dtEmpleado[0]);


            return objEmpleado;
        }

        public static int Insert(Empleados objEmpleados)
        {
            return Insert(objEmpleados.TxtNombre, objEmpleados.TxtApellidos, objEmpleados.TxtCI, objEmpleados.DateFechaNacimiento,objEmpleados.TxtPassword, objEmpleados.TxtDireccion, objEmpleados.TxtTelefono, objEmpleados.TxtCorreo, objEmpleados.DateFechaContrato, objEmpleados.IntFlagEstado, objEmpleados.IntTipo);
        }

      
        public static int Insert(string nombre,string apellido, string ci, DateTime? fechanac, string password, string direccion, string telefono, string correo, DateTime? fechaContrato, int? estado,int? tipo)
        {

            PracticaMVC.DAL.EmpleadoDSTableAdapters.EmpleadosTableAdapter objDataSet = new PracticaMVC.DAL.EmpleadoDSTableAdapters.EmpleadosTableAdapter();
            int? empleadoId = 0;
    
            //objDataSet.Insert1(ref empleadoId, nombre, apellido, ci, fechanac, password, direccion, telefono, correo, fechaContrato, estado, tipo);
            objDataSet.Insert1(ref empleadoId, nombre, apellido, ci,fechanac, password, direccion, telefono, correo, fechaContrato, estado, tipo);

            return (int)empleadoId;
        }

        public void Update(int pk,string nombre,string apellido, string ci, DateTime? fechanac, string password, string direccion, string telefono, string correo, DateTime? fechaContrato, int? estado,int? tipo)
        {
            PracticaMVC.DAL.EmpleadoDSTableAdapters.EmpleadosTableAdapter objDataSet = new PracticaMVC.DAL.EmpleadoDSTableAdapters.EmpleadosTableAdapter();
            objDataSet.Update1(pk,nombre,apellido,ci,fechanac,password,direccion,telefono,correo,fechaContrato,estado,tipo);
        }

    }
}