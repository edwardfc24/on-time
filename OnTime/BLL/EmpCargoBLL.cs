using OnTime.DAL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.BLL
{
    public class EmpCargoBLL
    {
        public EmpCargoBLL()
        {
        }
        public static EmpCargo rowToDto(EmpCargosDS.EmpCargosRow row)
        {
            EmpCargo objEmpCargo = new EmpCargo();
            objEmpCargo.pkEmpCargo = row.pkEmpCargo;
            objEmpCargo.fkEmpleado = row.fkEmpleado;
            objEmpCargo.fkCargo = row.fkCargo;
            return objEmpCargo;
        }

        public static List<EmpCargo> GetEmpCargoByIdEmpleado(int empleado)
        {
            List<EmpCargo> listadeEmpCargos = new List<EmpCargo>();

            OnTime.DAL.EmpCargosDSTableAdapters.EmpCargosTableAdapter objDataSet = new OnTime.DAL.EmpCargosDSTableAdapters.EmpCargosTableAdapter();
            EmpCargosDS.EmpCargosDataTable dtEmpCargo = objDataSet.GetCargoByIdEmpleado(empleado);

            foreach (EmpCargosDS.EmpCargosRow row in dtEmpCargo)
            {
                EmpCargo objEmpCargo = rowToDto(row);
                listadeEmpCargos.Add(objEmpCargo);
            }
            return listadeEmpCargos;
        }

        public static int InsertObjetoEmpCargo(EmpCargo objEmpCargos)
        {
            return InsertDatosEmpCargo(objEmpCargos.fkEmpleado, objEmpCargos.fkCargo);
        }


        public static int InsertDatosEmpCargo(int empleado, int cargo)
        {

            OnTime.DAL.EmpCargosDSTableAdapters.EmpCargosTableAdapter objDataSet = new OnTime.DAL.EmpCargosDSTableAdapters.EmpCargosTableAdapter();
            int? EmpCargoId = 0;

            //objDataSet.Insert1(ref EmpCargoId, nombre, apellido, ci, fechanac, password, direccion, telefono, correo, fechaContrato, estado, tipo);
            objDataSet.InsertEmpCargo(ref EmpCargoId, empleado, cargo);

            return (int)EmpCargoId;
        }
    }
}