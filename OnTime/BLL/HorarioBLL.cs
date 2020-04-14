using OnTime.DAL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.BLL
{
    public class HorarioBLL
    {
        private int pkHorario;

        public HorarioBLL()
        {
        }
        public static Horario rowToDto(HorariosDS.HorariosRow row)
        {
            Horario objHorario = new Horario();
            objHorario.pkHorario = row.pkHorario;
            objHorario.txtNombre = row.txtNombre;
            objHorario.tHoraEntrada = Convert.ToString(row.tHoraEntrada);
            objHorario.tHoraSalida = Convert.ToString(row.tHoraSalida);
            objHorario.txtDias = row.txtDias;
            objHorario.intEstado = row.intEstado;

            return objHorario;
        }
        public static List<Horario> SelectAll()
        {
            List<Horario> listadeHorarios = new List<Horario>();

            OnTime.DAL.HorariosDSTableAdapters.HorariosTableAdapter objDataSet = new OnTime.DAL.HorariosDSTableAdapters.HorariosTableAdapter();
            HorariosDS.HorariosDataTable dtHorario = objDataSet.GetAllHorarios();

            foreach (HorariosDS.HorariosRow row in dtHorario)
            {
                Horario objHorario = rowToDto(row);
                listadeHorarios.Add(objHorario);
            }
            return listadeHorarios;
        }

        public static Horario GetHorarioById(int pk)
        {
            List<Horario> listadeHorarios = new List<Horario>();

            OnTime.DAL.HorariosDSTableAdapters.HorariosTableAdapter objDataSet = new OnTime.DAL.HorariosDSTableAdapters.HorariosTableAdapter();
            HorariosDS.HorariosDataTable dtHorario = objDataSet.GetHorarioById(pk);
            Horario objHorario = rowToDto(dtHorario[0]);

            return objHorario;
        }

        public static int InsertObjetoHorario(Horario objHorarios)
        {
            return InsertDatosHorario(objHorarios.txtNombre, objHorarios.tHoraEntrada, objHorarios.tHoraSalida, objHorarios.txtDias, objHorarios.intEstado);
        }


        public static int InsertDatosHorario(string nombre, string horaEntrada, string horaSalida, string dias, int estado)
        {

            OnTime.DAL.HorariosDSTableAdapters.HorariosTableAdapter objDataSet = new OnTime.DAL.HorariosDSTableAdapters.HorariosTableAdapter();
            int? HorarioId = 0;

            //objDataSet.Insert1(ref HorarioId, nombre, apellido, ci, fechanac, password, direccion, telefono, correo, fechaContrato, estado, tipo);
            objDataSet.InsertHorario(ref HorarioId, nombre, horaEntrada, horaSalida, dias, estado);

            return (int)HorarioId;
        }

        public void UpdateHorario(int pk, string nombre, string horaEntrada, string horaSalida, string dias, int estado)
        {
            OnTime.DAL.HorariosDSTableAdapters.HorariosTableAdapter objDataSet = new OnTime.DAL.HorariosDSTableAdapters.HorariosTableAdapter();
            objDataSet.UpdateHorario(pk, nombre, horaEntrada, horaSalida, dias, estado);
        }

    }
}