using OnTime.DAL;
using OnTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.BLL
{
    public class DepartamentoBLL
    {
        public DepartamentoBLL()
        { }

        public static Departamento rowToDto(DepartamentosDS.DepartamentosRow row)
        {
            Departamento objDepartamento = new Departamento();

            objDepartamento.pkDepartamento = row.pkDepartamento;
            objDepartamento.txtNombre = row.txtNombre;
            objDepartamento.fkJefe = row.fkJefe;

            return objDepartamento;
        }
        public static List<Departamento> SelectAll()
        {
            List<Departamento> listadeDepartamento = new List<Departamento>();
            OnTime.DAL.DepartamentosDSTableAdapters.DepartamentosTableAdapter objDataSet = new OnTime.DAL.DepartamentosDSTableAdapters.DepartamentosTableAdapter();
            DepartamentosDS.DepartamentosDataTable dtDepartamento = objDataSet.GetAllDepartamentos();

            foreach (DepartamentosDS.DepartamentosRow row in dtDepartamento)
            {
                Departamento objEmpleado = rowToDto(row);
                listadeDepartamento.Add(objEmpleado);
            }
            return listadeDepartamento;
        }
        public static Departamento GetEmpleadoById(int pk)
        {
            List<Departamento> listadeDepartamento = new List<Departamento>();
            OnTime.DAL.DepartamentosDSTableAdapters.DepartamentosTableAdapter objDataSet = new OnTime.DAL.DepartamentosDSTableAdapters.DepartamentosTableAdapter();
            DepartamentosDS.DepartamentosDataTable dtDepartamento = objDataSet.GetDepartamentoByID(pk);
            Departamento objDepartamento = rowToDto(dtDepartamento[0]);

            return objDepartamento;
        }
        public static int InsertObjetoDepartamento(Departamento objDepartamento)
        {
            return InsertDatosDepartamento(objDepartamento.txtNombre, objDepartamento.fkJefe);
        }


        public static int InsertDatosDepartamento(string nombre, int jefe)
        {

            OnTime.DAL.DepartamentosDSTableAdapters.DepartamentosTableAdapter objDataSet = new OnTime.DAL.DepartamentosDSTableAdapters.DepartamentosTableAdapter();
            int? departamentoId = 0;

            //objDataSet.Insert1(ref empleadoId, nombre, apellido, ci, fechanac, password, direccion, telefono, correo, fechaContrato, estado, tipo);
            objDataSet.InsertDepartamento(ref departamentoId, nombre, jefe);

            return (int)departamentoId;
        }

        public static void UpdateDepartamento(Departamento objDepartamento)
        {
             UpdateDepartamento(objDepartamento.pkDepartamento,objDepartamento.txtNombre,objDepartamento.fkJefe);
        }

        public static void UpdateDepartamento(int? pk,string nombre, int fkJefe)
        {
            OnTime.DAL.DepartamentosDSTableAdapters.DepartamentosTableAdapter objDataSet = new OnTime.DAL.DepartamentosDSTableAdapters.DepartamentosTableAdapter();
            
            objDataSet.UpdateDepartamento(pk,nombre, fkJefe);
        }
    }
}