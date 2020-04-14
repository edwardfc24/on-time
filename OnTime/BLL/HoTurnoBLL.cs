using OnTime.DAL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.BLL
{
    public class HoTurnoBLL
    {
        public HoTurnoBLL()
        {
        }
        public static HoTurno rowToDto(HoTurnosDS.HoTurnosRow row)
        {
            HoTurno objHoTurno = new HoTurno();
            objHoTurno.pkHoTurno = row.pkHoTurno;
            objHoTurno.fkHorario = row.fkHorario;
            objHoTurno.fkTurno = row.fkTurno;

            return objHoTurno;
        }

        public static HoTurno GetHoTurnoById(int pk)
        {
            List<HoTurno> listadeHoTurnos = new List<HoTurno>();

            OnTime.DAL.HoTurnosDSTableAdapters.HoTurnosTableAdapter objDataSet = new OnTime.DAL.HoTurnosDSTableAdapters.HoTurnosTableAdapter();
            HoTurnosDS.HoTurnosDataTable dtHoTurno = objDataSet.GetHoTurnoByID(pk);
            HoTurno objHoTurno = rowToDto(dtHoTurno[0]);

            return objHoTurno;
        }

        public static List<HoTurno> GetHoTurnoByIdTurno(int turno)
        {
            List<HoTurno> listadeHoTurnos = new List<HoTurno>();

            OnTime.DAL.HoTurnosDSTableAdapters.HoTurnosTableAdapter objDataSet = new OnTime.DAL.HoTurnosDSTableAdapters.HoTurnosTableAdapter();
            HoTurnosDS.HoTurnosDataTable dtHoTurno = objDataSet.GetHoTurnoByIdTurno(turno);

            foreach (HoTurnosDS.HoTurnosRow row in dtHoTurno)
            {
                HoTurno objHoTurno = rowToDto(row);
                listadeHoTurnos.Add(objHoTurno);
            }
            return listadeHoTurnos;
        }

        public static int InsertObjetoHoTurno(HoTurno objHoTurnos)
        {
            return InsertDatosHoTurno(objHoTurnos.fkHorario, objHoTurnos.fkTurno);
        }


        public static int InsertDatosHoTurno(int horario, int turno)
        {

            OnTime.DAL.HoTurnosDSTableAdapters.HoTurnosTableAdapter objDataSet = new OnTime.DAL.HoTurnosDSTableAdapters.HoTurnosTableAdapter();
            int? HoTurnoId = 0;

            //objDataSet.Insert1(ref HoTurnoId, nombre, apellido, ci, fechanac, password, direccion, telefono, correo, fechaContrato, estado, tipo);
            objDataSet.InsertHoTurno(ref HoTurnoId, horario, turno);

            return (int)HoTurnoId;
        }

        public void UpdateHoTurno(int pk, int horario, int turno)
        {
            OnTime.DAL.HoTurnosDSTableAdapters.HoTurnosTableAdapter objDataSet = new OnTime.DAL.HoTurnosDSTableAdapters.HoTurnosTableAdapter();
            objDataSet.UpdateHoTurno(pk, horario, turno);
        }

    }
}