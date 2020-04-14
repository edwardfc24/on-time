using OnTime.DAL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.BLL
{
    public class PermisoBLL
    {
        public PermisoBLL()
        {
        }
        public static Permiso rowToDto(PermisosDS.PermisosRow row)
        {
            Permiso objPermiso = new Permiso();
            objPermiso.pkPermiso = row.pkPermiso;
            objPermiso.txtDescripcion = row.txtDescripcion;
            objPermiso.intEstado = row.intEstado;

            return objPermiso;
        }
        public static List<Permiso> SelectAll()
        {
            List<Permiso> listadePermisos = new List<Permiso>();

            OnTime.DAL.PermisosDSTableAdapters.PermisosTableAdapter objDataSet = new OnTime.DAL.PermisosDSTableAdapters.PermisosTableAdapter();
            PermisosDS.PermisosDataTable dtPermiso = objDataSet.GetAllPermisos();

            foreach (PermisosDS.PermisosRow row in dtPermiso)
            {
                Permiso objPermiso = rowToDto(row);
                listadePermisos.Add(objPermiso);
            }
            return listadePermisos;
        }

        public static Permiso GetPermisoById(int pk)
        {
            List<Permiso> listadePermisos = new List<Permiso>();

            OnTime.DAL.PermisosDSTableAdapters.PermisosTableAdapter objDataSet = new OnTime.DAL.PermisosDSTableAdapters.PermisosTableAdapter();
            PermisosDS.PermisosDataTable dtPermiso = objDataSet.GetPermisoById(pk);
            Permiso objPermiso = rowToDto(dtPermiso[0]);

            return objPermiso;
        }

        public static int InsertObjetoPermiso(Permiso objPermisos)
        {
            return InsertDatosPermiso(objPermisos.txtDescripcion, objPermisos.intEstado);
        }


        public static int InsertDatosPermiso(string descripcion, int? estado)
        {

            OnTime.DAL.PermisosDSTableAdapters.PermisosTableAdapter objDataSet = new OnTime.DAL.PermisosDSTableAdapters.PermisosTableAdapter();
            int? PermisoId = 0;

            //objDataSet.Insert1(ref PermisoId, nombre, apellido, ci, fechanac, password, direccion, telefono, correo, fechaContrato, estado, tipo);
            objDataSet.InsertPermiso(ref PermisoId, descripcion, estado);

            return (int)PermisoId;
        }

        public void UpdatePermiso(int? pk, string descripcion, int estado)
        {
            OnTime.DAL.PermisosDSTableAdapters.PermisosTableAdapter objDataSet = new OnTime.DAL.PermisosDSTableAdapters.PermisosTableAdapter();
            objDataSet.UpdatePermiso(ref pk, descripcion, estado);
        }

    }
}