using OnTime.DAL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.BLL
{
    public class RegDiarioBLL
    {
        public RegDiarioBLL()
        {
        }
        public static RegDiario rowToDto(RegDiariosDS.RegDiarioRow row)
        {
            RegDiario objRegDiario = new RegDiario();
            objRegDiario.pkRegDiario = row.pkRegDiario;
            objRegDiario.dateFechaActual = row.dateFechaActual;
            objRegDiario.tHoraEntradaReal = Convert.ToString(row.tHoraEntradaReal);
            objRegDiario.tHoraSalidaReal = Convert.ToString(row.tHoraSalidaReal);
            objRegDiario.tHoraEntrada = Convert.ToString(row.tHoraEntrada);
            objRegDiario.tHoraSalida = Convert.ToString(row.tHoraSalida);
            objRegDiario.txtNombreHorario = row.txtNombreHorario;
            objRegDiario.fkEmpleado = row.fkEmpleado;
            return objRegDiario;
        }
        public static List<RegDiario> GetHorariosByIDEmpleado(int idEmpleado)
        {
            List<RegDiario> listadeRegDiarios = new List<RegDiario>();

            OnTime.DAL.RegDiariosDSTableAdapters.RegDiarioTableAdapter objDataSet = new OnTime.DAL.RegDiariosDSTableAdapters.RegDiarioTableAdapter();
            RegDiariosDS.RegDiarioDataTable dtRegDiario = objDataSet.GetRegDiarioByIDEmpleado(idEmpleado);

            foreach (RegDiariosDS.RegDiarioRow row in dtRegDiario)
            {
                RegDiario objRegDiario = rowToDto(row);
                listadeRegDiarios.Add(objRegDiario);
            }
            return listadeRegDiarios;
        }

        public static void UpdateRegDiario(int pk, string hora, int tipo)
        {
            OnTime.DAL.RegDiariosDSTableAdapters.RegDiarioTableAdapter objDataSet = new OnTime.DAL.RegDiariosDSTableAdapters.RegDiarioTableAdapter();
            objDataSet.UpdateRegistroDiario(pk, hora, tipo);
        }

    }
}