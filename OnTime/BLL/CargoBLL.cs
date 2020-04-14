using OnTime.DAL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnTime.BLL
{
    public class CargoBLL
    {
        public CargoBLL()
        { }

        public static Cargo rowToDto(CargoDS.CargosRow row)
        {
            Cargo objCargo = new Cargo();

            objCargo.pkCargo = row.pkCargo;
            objCargo.txtNombre = row.txtNombre;
            objCargo.fkDepartamento = row.fkDepartamento;

            return objCargo;
        }
        public static List<Cargo> SelectAll()
        {
            List<Cargo> listadeCargos = new List<Cargo>();
            OnTime.DAL.CargoDSTableAdapters.CargosTableAdapter objDataSet = new OnTime.DAL.CargoDSTableAdapters.CargosTableAdapter();
            CargoDS.CargosDataTable dtDepartamento = objDataSet.GetAllCargos();

            foreach (CargoDS.CargosRow row in dtDepartamento)
            {
                Cargo objCargo = rowToDto(row);
                listadeCargos.Add(objCargo);
            }
            return listadeCargos;
        }
        public static int InsertObjetoCargo(Cargo objCargo)
        {
            return InsertDatosCargo(objCargo.txtNombre, objCargo.fkDepartamento);
        }


        public static int InsertDatosCargo(string nombre, int dpto)
        {

            OnTime.DAL.CargoDSTableAdapters.CargosTableAdapter objDataSet = new OnTime.DAL.CargoDSTableAdapters.CargosTableAdapter();
            int? cargoId = 0;

            //objDataSet.Insert1(ref empleadoId, nombre, apellido, ci, fechanac, password, direccion, telefono, correo, fechaContrato, estado, tipo);
            objDataSet.InsertCargo(ref cargoId, nombre, dpto);

            return (int)cargoId;
        }

        public static List<Cargo> GetCargosByIdDpto(int dpto)
        {
            List<Cargo> listadeCargos = new List<Cargo>();
            OnTime.DAL.CargoDSTableAdapters.CargosTableAdapter objDataSet = new OnTime.DAL.CargoDSTableAdapters.CargosTableAdapter();
            CargoDS.CargosDataTable dtDepartamento = objDataSet.GetCargoByIdDepartamento(dpto);

            foreach (CargoDS.CargosRow row in dtDepartamento)
            {
                Cargo objCargo = rowToDto(row);
                listadeCargos.Add(objCargo);
            }
            return listadeCargos;
        }
        public static Cargo GetCargoById(int pk)
        {
            List<Cargo> listadeCargo = new List<Cargo>();
            OnTime.DAL.CargoDSTableAdapters.CargosTableAdapter objDataSet = new OnTime.DAL.CargoDSTableAdapters.CargosTableAdapter();
            CargoDS.CargosDataTable dtDepartamento = objDataSet.GetCargosById(pk);
            Cargo objDepartamento = rowToDto(dtDepartamento[0]);

            return objDepartamento;
        }
        public static void UpdateCargo(Cargo objDepartamento)
        {
            UpdateCargo(objDepartamento.pkCargo, objDepartamento.txtNombre, objDepartamento.pkCargo);
        }

        public static void UpdateCargo(int? pk, string nombre, int fkJefe)
        {
            OnTime.DAL.CargoDSTableAdapters.CargosTableAdapter objDataSet = new OnTime.DAL.CargoDSTableAdapters.CargosTableAdapter();

            objDataSet.UpdateCargo(pk, nombre, fkJefe);
        }
    }
}
