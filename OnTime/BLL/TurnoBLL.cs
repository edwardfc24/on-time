using OnTime.DAL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.BLL
{
    public class TurnoBLL
    {
        public TurnoBLL()
        {
        }
        public static Turno rowToDto(TurnosDS.TurnosRow row)
        {
            Turno objTurno = new Turno();
            objTurno.pkTurno = row.pkTurno;
            objTurno.txtNombre = row.txtNombre;
            objTurno.intEstado = row.intEstado;

            return objTurno;
        }
        public static List<Turno> SelectAll()
        {
            List<Turno> listadeTurnos = new List<Turno>();

            OnTime.DAL.TurnosDSTableAdapters.TurnosTableAdapter objDataSet = new OnTime.DAL.TurnosDSTableAdapters.TurnosTableAdapter();
            TurnosDS.TurnosDataTable dtTurno = objDataSet.GetAllTurnos();

            foreach (TurnosDS.TurnosRow row in dtTurno)
            {
                Turno objTurno = rowToDto(row);
                listadeTurnos.Add(objTurno);
            }
            return listadeTurnos;
        }

        public static Turno GetTurnoById(int pk)
        {
            List<Turno> listadeTurnos = new List<Turno>();

            OnTime.DAL.TurnosDSTableAdapters.TurnosTableAdapter objDataSet = new OnTime.DAL.TurnosDSTableAdapters.TurnosTableAdapter();
            TurnosDS.TurnosDataTable dtTurno = objDataSet.GetTurnoById(pk);
            Turno objTurno = rowToDto(dtTurno[0]);

            return objTurno;
        }

        public static int InsertObjetoTurno(Turno objTurnos)
        {
            return InsertDatosTurno(objTurnos.txtNombre, objTurnos.intEstado);
        }


        public static int InsertDatosTurno(string nombre, int estado)
        {

            OnTime.DAL.TurnosDSTableAdapters.TurnosTableAdapter objDataSet = new OnTime.DAL.TurnosDSTableAdapters.TurnosTableAdapter();
            int? TurnoId = 0;

            //objDataSet.Insert1(ref TurnoId, nombre, apellido, ci, fechanac, password, direccion, telefono, correo, fechaContrato, estado, tipo);
            objDataSet.InsertTurno(ref TurnoId, nombre, estado);

            return (int)TurnoId;
        }

        public void UpdateTurno(int pk, string nombre, int estado)
        {
            OnTime.DAL.TurnosDSTableAdapters.TurnosTableAdapter objDataSet = new OnTime.DAL.TurnosDSTableAdapters.TurnosTableAdapter();
            objDataSet.UpdateTurno(pk, nombre, estado);
        }

    }
}