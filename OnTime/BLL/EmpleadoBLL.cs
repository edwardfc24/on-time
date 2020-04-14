using OnTime.DAL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.BLL
{
    public class EmpleadoBLL
    {
        public EmpleadoBLL()
        {
        }
        public static Empleado rowToDto(EmpleadosDS.EmpleadosRow row)
        {
            Empleado objEmpleado = new Empleado();
            objEmpleado.pkEmpleado = row.pkEmpleado;
            objEmpleado.txtNombre = row.txtNombre;
            objEmpleado.txtApellidos = row.txtApellidos;
            objEmpleado.txtCI = row.txtCI;
            objEmpleado.dateFechaNacimiento = row.dateFechaNacimiento;
            objEmpleado.txtPassword = System.Text.Encoding.UTF8.GetString(row.txtPassword);
            objEmpleado.txtDireccion = row.txtDireccion;
            objEmpleado.txtCorreo = row.txtCorreo;
            objEmpleado.dateFechaContrato = row.dateFechaContrato;
            objEmpleado.intFlagEstado = row.intFlagEstado;
            objEmpleado.intTipo = row.intTipo;
            objEmpleado.fullName = (row.txtNombre + " " + row.txtApellidos);
            return objEmpleado;
        }
        public static ConsultaMarcador rowToDtoC(EmpleadosDS.CTEmpleadoByCIRow row)
        {
            ConsultaMarcador objEmpleado = new ConsultaMarcador();
            objEmpleado.txtNombre = row.txtNombre;
            objEmpleado.txtNombre1 = row.txtNombre1;
            objEmpleado.txtNomrbeTurno = row.NomrbeTurno;
            objEmpleado.tHoraEntrada = row.tHoraEntrada;
            objEmpleado.tHoraSalida = row.tHoraSalida;
            objEmpleado.txtDias = row.txtDias;
            return objEmpleado;
        }
        public static List<Empleado> SelectAll()
        {
            List<Empleado> listadeEmpleados = new List<Empleado>();

            OnTime.DAL.EmpleadosDSTableAdapters.EmpleadosTableAdapter objDataSet = new OnTime.DAL.EmpleadosDSTableAdapters.EmpleadosTableAdapter();
            EmpleadosDS.EmpleadosDataTable dtEmpleado = objDataSet.GetAllEmpleados();

            foreach (EmpleadosDS.EmpleadosRow row in dtEmpleado)
            {
                Empleado objEmpleado = rowToDto(row);
                listadeEmpleados.Add(objEmpleado);
            }
            return listadeEmpleados;
        }

        public static Empleado GetEmpleadoById(int pk)
        {
            List<Empleado> listadeEmpleados = new List<Empleado>();

            OnTime.DAL.EmpleadosDSTableAdapters.EmpleadosTableAdapter objDataSet = new OnTime.DAL.EmpleadosDSTableAdapters.EmpleadosTableAdapter();
            EmpleadosDS.EmpleadosDataTable dtEmpleado = objDataSet.GetEmpleadoByID(pk);
            Empleado objEmpleado = rowToDto(dtEmpleado[0]);

            return objEmpleado;
        }

        public static int InsertObjetoEmpleado(Empleado objEmpleados)
        {
            return InsertDatosEmpleado(objEmpleados.txtNombre, objEmpleados.txtApellidos, objEmpleados.txtCI, objEmpleados.dateFechaNacimiento, objEmpleados.txtPassword, objEmpleados.txtDireccion, objEmpleados.txtTelefono, objEmpleados.txtCorreo, objEmpleados.dateFechaContrato, objEmpleados.intFlagEstado, objEmpleados.intTipo);
        }


        public static int InsertDatosEmpleado(string nombre, string apellido, string ci, DateTime? fechanac, string password, string direccion, string telefono, string correo, DateTime? fechaContrato, int? estado, int? tipo)
        {

            OnTime.DAL.EmpleadosDSTableAdapters.EmpleadosTableAdapter objDataSet = new OnTime.DAL.EmpleadosDSTableAdapters.EmpleadosTableAdapter();
            int? empleadoId = 0;

            //objDataSet.Insert1(ref empleadoId, nombre, apellido, ci, fechanac, password, direccion, telefono, correo, fechaContrato, estado, tipo);
            objDataSet.InsertEmpleado(ref empleadoId, nombre, apellido, ci, fechanac, password, direccion, telefono, correo, fechaContrato, estado, tipo);

            return (int)empleadoId;
        }

        public static void UpdateEmpleado(Empleado objEmpleados)
        {
            UpdateEmpleado(objEmpleados.pkEmpleado, objEmpleados.txtNombre, objEmpleados.txtApellidos, objEmpleados.txtCI, objEmpleados.dateFechaNacimiento, objEmpleados.txtPassword, objEmpleados.txtDireccion, objEmpleados.txtTelefono, objEmpleados.txtCorreo, objEmpleados.dateFechaContrato, objEmpleados.intFlagEstado, objEmpleados.intTipo);
        }

        public static void UpdateEmpleado(int pk, string nombre, string apellido, string ci, DateTime? fechanac, string password, string direccion, string telefono, string correo, DateTime? fechaContrato, int? estado, int? tipo)
        {
            OnTime.DAL.EmpleadosDSTableAdapters.EmpleadosTableAdapter objDataSet = new OnTime.DAL.EmpleadosDSTableAdapters.EmpleadosTableAdapter();
            objDataSet.UpdateEmpleado(pk, nombre, apellido, ci, fechanac, password, direccion, telefono, correo, fechaContrato, estado, tipo);
        }

        public static Empleado GetEmpleadoByNameAndPass(string name, string pass)
        {
           
            OnTime.DAL.EmpleadosDSTableAdapters.EmpleadosTableAdapter objDataSet = new OnTime.DAL.EmpleadosDSTableAdapters.EmpleadosTableAdapter();
            EmpleadosDS.EmpleadosDataTable dtEmpleado = objDataSet.GetEmpleadoByNameAndPass(name, pass);
            if (dtEmpleado.Rows.Count > 0)
            {
                Empleado objEmpleado = rowToDto(dtEmpleado[0]);

                return objEmpleado;
            }
            else
            {
                return null;
            }
        }
        public static Empleado GetEmpleadoByCI(string ci)
        {
            OnTime.DAL.EmpleadosDSTableAdapters.EmpleadosTableAdapter objDataSet = new OnTime.DAL.EmpleadosDSTableAdapters.EmpleadosTableAdapter();
            EmpleadosDS.EmpleadosDataTable dtEmpleado = objDataSet.GetEmpleadoByCI(ci);
            if (dtEmpleado.Rows.Count > 0)
            {
                Empleado objEmpleado = rowToDto(dtEmpleado[0]);

                return objEmpleado;
            }
            else
            {
                return null;
            }
        }
        public static ConsultaMarcador GetCTEmpleadoByCI(string ci,string dias)
        {
            OnTime.DAL.EmpleadosDSTableAdapters.CTEmpleadoByCITableAdapter objDataSet = new OnTime.DAL.EmpleadosDSTableAdapters.CTEmpleadoByCITableAdapter();
            EmpleadosDS.CTEmpleadoByCIDataTable dtEmpleado = objDataSet.GetData(ci,dias);
            if (dtEmpleado.Rows.Count > 0)
            {
                ConsultaMarcador objEmpleado = rowToDtoC(dtEmpleado[0]);

                return objEmpleado;
            }
            else
            {
                return null;
            }
        }
    }
}