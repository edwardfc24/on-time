using OnTime.DAL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.BLL
{
    public class VacacionBLL
    {
        public VacacionBLL()
        {
        }

        public static Vacacion rowToDto(VacacionesDS.VacacionesRow row)
        {
            Vacacion objVacacion = new Vacacion();
            objVacacion.pkVacacion = row.pkVacacion;
            objVacacion.dateFechaInicio = row.dateFechaInicio;
            objVacacion.dateFechaFin = row.dateFechaFin;
            objVacacion.fkEmpleado = row.fkEmpleado;
            objVacacion.fkAutorizacion = row.fkAutorizacion;

            return objVacacion;
        }

        public static List<Vacacion> SelectAll()
        {
            List<Vacacion> listadeVacaciones = new List<Vacacion>();

            OnTime.DAL.VacacionesDSTableAdapters.VacacionesTableAdapter objDataSet = new OnTime.DAL.VacacionesDSTableAdapters.VacacionesTableAdapter();
            VacacionesDS.VacacionesDataTable dtVacacion = objDataSet.GetAllVacaciones();

            foreach (VacacionesDS.VacacionesRow row in dtVacacion)
            {
                Vacacion objVacacion = rowToDto(row);
                listadeVacaciones.Add(objVacacion);
            }
            return listadeVacaciones;
        }

        public static Vacacion GetVacacionById(int pk)
        {
            List<Vacacion> listadeVacaciones = new List<Vacacion>();

            OnTime.DAL.VacacionesDSTableAdapters.VacacionesTableAdapter objDataSet = new OnTime.DAL.VacacionesDSTableAdapters.VacacionesTableAdapter();
            VacacionesDS.VacacionesDataTable dtVacacion = objDataSet.GetVacacionByID(pk);
            Vacacion objVacacion = rowToDto(dtVacacion[0]);

            return objVacacion;
        }

        public static int InsertObjetoVacacion(Vacacion objVacaciones)
        {
            return InsertDatosVacacion(objVacaciones.dateFechaInicio, objVacaciones.dateFechaFin, objVacaciones.fkEmpleado, objVacaciones.fkAutorizacion);
        }

        public static int InsertDatosVacacion(DateTime? fechaInicio, DateTime? fechaFin, int empleado, int autorizacion)
        {

            OnTime.DAL.VacacionesDSTableAdapters.VacacionesTableAdapter objDataSet = new OnTime.DAL.VacacionesDSTableAdapters.VacacionesTableAdapter();
            int? VacacionId = 0;

            //objDataSet.Insert1(ref VacacionId, nombre, apellido, ci, fechanac, password, direccion, telefono, correo, fechaContrato, estado, tipo);
            objDataSet.InsertVacacion(ref VacacionId, fechaInicio, fechaFin, empleado, autorizacion);
            return (int)VacacionId;
        }

        public void UpdateVacacion(int pk, DateTime? fechaInicio, DateTime? fechaFin, int empleado, int autorizacion)
        {
            OnTime.DAL.VacacionesDSTableAdapters.VacacionesTableAdapter objDataSet = new OnTime.DAL.VacacionesDSTableAdapters.VacacionesTableAdapter();
            objDataSet.UpdateVacacion(pk, fechaInicio, fechaFin, empleado, autorizacion);
        }

        public static List<Vacacion> GetVacacionesByIdAutorizacion(int autorizacion)
        {
            List<Vacacion> listadeVacaciones = new List<Vacacion>();

            OnTime.DAL.VacacionesDSTableAdapters.VacacionesTableAdapter objDataSet = new OnTime.DAL.VacacionesDSTableAdapters.VacacionesTableAdapter();
            VacacionesDS.VacacionesDataTable dtVacacion = objDataSet.GetVacacionByIdAutorizacion(autorizacion);

            foreach (VacacionesDS.VacacionesRow row in dtVacacion)
            {
                Vacacion objVacacion = rowToDto(row);
                listadeVacaciones.Add(objVacacion);
            }
            return listadeVacaciones;
        }

        public static List<Vacacion> GetVacacionesByIdEmpleaso(int empleado)
        {
            List<Vacacion> listadeVacaciones = new List<Vacacion>();

            OnTime.DAL.VacacionesDSTableAdapters.VacacionesTableAdapter objDataSet = new OnTime.DAL.VacacionesDSTableAdapters.VacacionesTableAdapter();
            VacacionesDS.VacacionesDataTable dtVacacion = objDataSet.GetVacacionByIdEmpleado(empleado);

            foreach (VacacionesDS.VacacionesRow row in dtVacacion)
            {
                Vacacion objVacacion = rowToDto(row);
                listadeVacaciones.Add(objVacacion);
            }
            return listadeVacaciones;
        }
    }
}