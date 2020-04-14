using OnTime.DAL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.BLL
{
    public class ReporteCIBLL
    {
         public ReporteCIBLL()
        {
        }
        public static ReporteCI rowToDto(ReporteCIDS.ReporteRow row)
        {
            ReporteCI objReporte = new ReporteCI();
            objReporte.Empleado = row.Empleado;
            objReporte.HoraEntrada = row.HoraEntrada;
            objReporte.HoraEntradaActual = row.HoraEntradaActual;
            objReporte.DiferenciaEntrada = row.DiferenciaEntrada;
            objReporte.HoraSalida = row.HoraSalidaActual;
            objReporte.DiferenciaSalida = row.DifereciaSalida;
            objReporte.Fecha = row.Fecha;
            objReporte.CarnetIdentidad = row.CarnetIdentidad;
            objReporte.Horario = row.Horario;
            return objReporte;
        }
        public static List<ReporteCI> SelectAll()
        {
            List<ReporteCI> listaReporte = new List<ReporteCI>();

            OnTime.DAL.ReporteCIDSTableAdapters.ReporteTableAdapter objDataSet = new OnTime.DAL.ReporteCIDSTableAdapters.ReporteTableAdapter();
            ReporteCIDS.ReporteDataTable dtReporte = objDataSet.GetDataReporte();

            foreach (ReporteCIDS.ReporteRow row in dtReporte)
            {
                ReporteCI objReporte = rowToDto(row);
                listaReporte.Add(objReporte);
            }
            return listaReporte;
        }

    }

}