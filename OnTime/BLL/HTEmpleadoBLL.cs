using OnTime.DAL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.BLL
{
    public class HTEmpleadoBLL
    {
        public HTEmpleadoBLL()
        {
        }
        public static HTEmpleado rowToDto(HTEmpleadosDS.HTEmpleadosRow row)
        {
            HTEmpleado objHTEmpleado = new HTEmpleado();
            objHTEmpleado.pkHTEmpleado = row.pkHTEmpleado;
            objHTEmpleado.fkHoTurno = row.fkHoTurno;
            objHTEmpleado.fkEmpleado = row.fkEmpleado;

            return objHTEmpleado;
        }

        public static HTEmpleado GetHTEmpleadoById(int pk)
        {
            List<HTEmpleado> listadeHTEmpleados = new List<HTEmpleado>();

            OnTime.DAL.HTEmpleadosDSTableAdapters.HTEmpleadosTableAdapter objDataSet = new OnTime.DAL.HTEmpleadosDSTableAdapters.HTEmpleadosTableAdapter();
            HTEmpleadosDS.HTEmpleadosDataTable dtHTEmpleado = objDataSet.GetHTEmpleadoById(pk);
            HTEmpleado objHTEmpleado = rowToDto(dtHTEmpleado[0]);

            return objHTEmpleado;
        }

        public static List<HTEmpleado> GetHTEmpleadoByIdEmpleado(int empleado)
        {
            List<HTEmpleado> listadeHTEmpleados = new List<HTEmpleado>();

            OnTime.DAL.HTEmpleadosDSTableAdapters.HTEmpleadosTableAdapter objDataSet = new OnTime.DAL.HTEmpleadosDSTableAdapters.HTEmpleadosTableAdapter();
            HTEmpleadosDS.HTEmpleadosDataTable dtHTEmpleado = objDataSet.GetHTEmpleadoByIdEmpleado(empleado);

            foreach (HTEmpleadosDS.HTEmpleadosRow row in dtHTEmpleado)
            {
                HTEmpleado objHTEmpleado = rowToDto(row);
                listadeHTEmpleados.Add(objHTEmpleado);
            }
            return listadeHTEmpleados;
        }

        public static int InsertObjetoHTEmpleado(HTEmpleado objHTEmpleados)
        {
            return InsertDatosHTEmpleado(objHTEmpleados.fkHoTurno, objHTEmpleados.fkEmpleado);
        }


        public static int InsertDatosHTEmpleado(int hoTurno, int empleado)
        {

            OnTime.DAL.HTEmpleadosDSTableAdapters.HTEmpleadosTableAdapter objDataSet = new OnTime.DAL.HTEmpleadosDSTableAdapters.HTEmpleadosTableAdapter();
            int? HTEmpleadoId = 0;

            //objDataSet.Insert1(ref HTEmpleadoId, nombre, apellido, ci, fechanac, password, direccion, telefono, correo, fechaContrato, estado, tipo);
            objDataSet.InsertHTEmpleado(ref HTEmpleadoId, hoTurno, empleado);

            return (int)HTEmpleadoId;
        }

        public void UpdateHTEmpleado(int pk, int hoTurno, int empleado)
        {
            OnTime.DAL.HTEmpleadosDSTableAdapters.HTEmpleadosTableAdapter objDataSet = new OnTime.DAL.HTEmpleadosDSTableAdapters.HTEmpleadosTableAdapter();
            objDataSet.UpdateHTEmpleado(pk, hoTurno, empleado);
        }

        public void DeleteHTEmpleado(int pk)
        {
            OnTime.DAL.HTEmpleadosDSTableAdapters.HTEmpleadosTableAdapter objDataSet = new OnTime.DAL.HTEmpleadosDSTableAdapters.HTEmpleadosTableAdapter();
            objDataSet.DeleteHTEmpleadoById(pk);
        }

    }
}