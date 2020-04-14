using OnTime.DAL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.BLL
{
    public class EmpPermisoBLL
    {
        public EmpPermisoBLL()
        {
        }
        public static EmpPermiso rowToDto(EmpPermisosDS.EmpPermisosRow row)
        {
            EmpPermiso objEmpPermiso = new EmpPermiso();
            objEmpPermiso.pkEmpPermiso = row.pkEmpPermiso;
            objEmpPermiso.dateFechaInicio = row.dateFechaInicio;
            objEmpPermiso.dateFechafin = row.dateFechaFin;
            objEmpPermiso.tHoraInicio = Convert.ToString(row.tHoraInicio);
            objEmpPermiso.tHoraFin = Convert.ToString(row.tHoraFin);
            objEmpPermiso.fkEmpleado = row.fkEmpleado;
            objEmpPermiso.fkPermiso = row.fkPermiso;
            return objEmpPermiso;
        }
        public static List<EmpPermiso> SelectAll()
        {
            List<EmpPermiso> listadeEmpPermisos = new List<EmpPermiso>();

            OnTime.DAL.EmpPermisosDSTableAdapters.EmpPermisosTableAdapter objDataSet = new OnTime.DAL.EmpPermisosDSTableAdapters.EmpPermisosTableAdapter();
            EmpPermisosDS.EmpPermisosDataTable dtEmpPermiso = objDataSet.GetAllEmpPermisos();

            foreach (EmpPermisosDS.EmpPermisosRow row in dtEmpPermiso)
            {
                EmpPermiso objEmpPermiso = rowToDto(row);
                listadeEmpPermisos.Add(objEmpPermiso);
            }
            return listadeEmpPermisos;
        }

        public static EmpPermiso GetEmpPermisoById(int pk)
        {
            List<EmpPermiso> listadeEmpPermisos = new List<EmpPermiso>();

            OnTime.DAL.EmpPermisosDSTableAdapters.EmpPermisosTableAdapter objDataSet = new OnTime.DAL.EmpPermisosDSTableAdapters.EmpPermisosTableAdapter();
            EmpPermisosDS.EmpPermisosDataTable dtEmpPermiso = objDataSet.GetEmpPermisoByID(pk);
            EmpPermiso objEmpPermiso = rowToDto(dtEmpPermiso[0]);

            return objEmpPermiso;
        }

        public static int InsertObjetoEmpPermiso(EmpPermiso objEmpPermisos)
        {
            return InsertDatosEmpPermiso(objEmpPermisos.dateFechaInicio, objEmpPermisos.dateFechafin, objEmpPermisos.fkPermiso, objEmpPermisos.tHoraInicio, objEmpPermisos.tHoraFin, objEmpPermisos.fkEmpleado);
        }


        public static int InsertDatosEmpPermiso(DateTime? fechaInicio, DateTime? fechaFin, int permiso, string horaInicio, string horaFin, int empleado)
        {

            OnTime.DAL.EmpPermisosDSTableAdapters.EmpPermisosTableAdapter objDataSet = new OnTime.DAL.EmpPermisosDSTableAdapters.EmpPermisosTableAdapter();
            int? EmpPermisoId = 0;

            //objDataSet.Insert1(ref EmpPermisoId, nombre, apellido, ci, fechanac, password, direccion, telefono, correo, fechaContrato, estado, tipo);
            objDataSet.InsertEmpPermiso(ref EmpPermisoId, fechaInicio, fechaFin, permiso, horaInicio, horaFin, empleado);

            return (int)EmpPermisoId;
        }

        public static void UpdateEmpPermiso(EmpPermiso objEmpPermisos)
        {
            UpdateEmpPermiso(objEmpPermisos.pkEmpPermiso, objEmpPermisos.dateFechaInicio, objEmpPermisos.dateFechafin, objEmpPermisos.fkPermiso, objEmpPermisos.tHoraInicio, objEmpPermisos.tHoraFin, objEmpPermisos.fkEmpleado);
        }

        public static void UpdateEmpPermiso(int pk, DateTime? fechaInicio, DateTime? fechaFin, int permiso, string horaInicio, string horaFin, int empleado)
        {
            OnTime.DAL.EmpPermisosDSTableAdapters.EmpPermisosTableAdapter objDataSet = new OnTime.DAL.EmpPermisosDSTableAdapters.EmpPermisosTableAdapter();
            objDataSet.UpdateEmpPermiso(pk, fechaInicio, fechaFin, permiso, horaInicio, horaFin, empleado);
        }

    }
}