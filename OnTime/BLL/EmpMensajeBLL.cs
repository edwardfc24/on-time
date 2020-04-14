using OnTime.DAL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.BLL
{
    public class EmpMensajeBLL
    {
        public EmpMensajeBLL()
        {
        }
        public static EmpMensaje rowToDto(EmpMensajesDS.EmpMensajesRow row)
        {
            EmpMensaje objEmpMensaje = new EmpMensaje();
            objEmpMensaje.pkEmpMensaje = row.pkEmpMensaje;
            objEmpMensaje.fkMensaje = row.fkMensaje;
            objEmpMensaje.fkEmpleado = row.fkEmpleado;
            return objEmpMensaje;
        }

        public static List<EmpMensaje> GetMensajePkByIdEmpleado(int empleado)
        {
            List<EmpMensaje> listadeEmpMensajes = new List<EmpMensaje>();

            OnTime.DAL.EmpMensajesDSTableAdapters.EmpMensajesTableAdapter objDataSet = new OnTime.DAL.EmpMensajesDSTableAdapters.EmpMensajesTableAdapter();
            EmpMensajesDS.EmpMensajesDataTable dtEmpMensaje = objDataSet.GetMensajeByIdEmpleado(empleado);

            foreach (EmpMensajesDS.EmpMensajesRow row in dtEmpMensaje)
            {
                EmpMensaje objEmpMensaje = rowToDto(row);
                listadeEmpMensajes.Add(objEmpMensaje);
            }
            return listadeEmpMensajes;
        }

        public static int InsertObjetoEmpMensaje(EmpMensaje objEmpMensajes)
        {
            return InsertDatosEmpMensaje(objEmpMensajes.fkMensaje, objEmpMensajes.fkEmpleado);
        }


        public static int InsertDatosEmpMensaje(int mensaje, int empleado)
        {

            OnTime.DAL.EmpMensajesDSTableAdapters.EmpMensajesTableAdapter objDataSet = new OnTime.DAL.EmpMensajesDSTableAdapters.EmpMensajesTableAdapter();
            int? EmpMensajeId = 0;

            //objDataSet.Insert1(ref EmpMensajeId, nombre, apellido, ci, fechanac, password, direccion, telefono, correo, fechaContrato, estado, tipo);
            objDataSet.InsertEmpMensaje(ref EmpMensajeId, mensaje, empleado);

            return (int)EmpMensajeId;
        }

    }
}