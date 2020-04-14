using OnTime.DAL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.BLL
{
    public class MensajeBLL
    {
        public MensajeBLL()
        {
        }
        public static Mensaje rowToDto(MensajesDS.MensajesRow row)
        {
            Mensaje objMensaje = new Mensaje();
            objMensaje.pkMensaje = row.pkMensaje;
            objMensaje.txtDescripcion = row.txtDescripcion;
            objMensaje.fkRemitente = row.fkRemitente;

            return objMensaje;
        }
        public static List<Mensaje> SelectAll()
        {
            List<Mensaje> listadeMensajes = new List<Mensaje>();

            OnTime.DAL.MensajesDSTableAdapters.MensajesTableAdapter objDataSet = new OnTime.DAL.MensajesDSTableAdapters.MensajesTableAdapter();
            MensajesDS.MensajesDataTable dtMensaje = objDataSet.GetAllMensajes();

            foreach (MensajesDS.MensajesRow row in dtMensaje)
            {
                Mensaje objMensaje = rowToDto(row);
                listadeMensajes.Add(objMensaje);
            }
            return listadeMensajes;
        }

        public static Mensaje GetMensajeById(int pk)
        {
            List<Mensaje> listadeMensajes = new List<Mensaje>();

            OnTime.DAL.MensajesDSTableAdapters.MensajesTableAdapter objDataSet = new OnTime.DAL.MensajesDSTableAdapters.MensajesTableAdapter();
            MensajesDS.MensajesDataTable dtMensaje = objDataSet.GetMensajeByID(pk);
            Mensaje objMensaje = rowToDto(dtMensaje[0]);

            return objMensaje;
        }

        public static Mensaje GetMensajeByIdEmpleado(int pk)
        {
            List<Mensaje> listadeMensajes = new List<Mensaje>();

            OnTime.DAL.MensajesDSTableAdapters.MensajesTableAdapter objDataSet = new OnTime.DAL.MensajesDSTableAdapters.MensajesTableAdapter();
            MensajesDS.MensajesDataTable dtMensaje = objDataSet.GetMensajesByIdEmpleado(pk);
            Mensaje objMensaje = rowToDto(dtMensaje[0]);

            return objMensaje;
        }

        public static int InsertObjetoMensaje(Mensaje objMensajes)
        {
            return InsertDatosMensaje(objMensajes.txtDescripcion, objMensajes.fkRemitente);
        }


        public static int InsertDatosMensaje(string desc, int? remitente)
        {

            OnTime.DAL.MensajesDSTableAdapters.MensajesTableAdapter objDataSet = new OnTime.DAL.MensajesDSTableAdapters.MensajesTableAdapter();
            int? MensajeId = 0;

            //objDataSet.Insert1(ref MensajeId, nombre, apellido, ci, fechanac, password, direccion, telefono, correo, fechaContrato, estado, tipo);
            objDataSet.InsertMensaje(ref MensajeId, desc, remitente);

            return (int)MensajeId;
        }

    }
}