using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD
{
    public class CAD
    {
        DbProviderFactory dpfProxy;

        public void Fabricar(string strDBKey)
        {
            //Singleton
            if (dpfProxy == null)
            {
                string strProvider = ConfigurationManager.ConnectionStrings[strDBKey].ProviderName;
                dpfProxy = DbProviderFactories.GetFactory(strProvider);
            }
        }
        private DbConnection Conectar(string strDBKey)
        {
            this.Fabricar(strDBKey);
            string strConeccion = ConfigurationManager.ConnectionStrings[strDBKey].ConnectionString;
            DbConnection conConeccion = dpfProxy.CreateConnection();
            conConeccion.ConnectionString = strConeccion;
            conConeccion.Open();
            return conConeccion;
        }
        private DbCommand CrearComando()
        {
            DbCommand cmdComando = dpfProxy.CreateCommand();
            return cmdComando;
        }
        private DbDataAdapter CrearAdaptador()
        {
            DbDataAdapter datAdaptador = dpfProxy.CreateDataAdapter();
            return datAdaptador;
        }
        protected DbDataAdapter CrearAdaptador(string strNombreTabla, string strDBKey)
        {
            DbConnection conProxy = this.Conectar(strDBKey);
            string strSelect = string.Format("SELECT * FROM {0}", strNombreTabla);
            DbCommand cmdProxy = this.CrearComando();
            cmdProxy.CommandText = strSelect;
            cmdProxy.Connection = conProxy;

            DbDataAdapter adaProxy = this.CrearAdaptador();
            adaProxy.SelectCommand = cmdProxy;

            DbCommandBuilder cblProxy = dpfProxy.CreateCommandBuilder();
            cblProxy.DataAdapter = adaProxy;
            cblProxy.ConflictOption = ConflictOption.OverwriteChanges;

            //adaProxy.InsertCommand = cblProxy.GetInsertCommand(true);
            //adaProxy.DeleteCommand = cblProxy.GetDeleteCommand(true);
            //adaProxy.UpdateCommand = cblProxy.GetUpdateCommand(true);

            return adaProxy;
        }
        public DataSet EjecutarConsulta(string strSelect, string strDBKey)
        {
            DbConnection conProxy = this.Conectar(strDBKey);
            DbCommand cmdProxy = this.CrearComando();
            cmdProxy.CommandText = strSelect;
            cmdProxy.Connection = conProxy;

            DbDataAdapter adaProxy = this.CrearAdaptador();
            adaProxy.SelectCommand = cmdProxy;

            DataSet dtpProxy = new DataSet();
            adaProxy.Fill(dtpProxy);
            conProxy.Close();
            return dtpProxy;
        }
        public DataSet EjecutarConsulta(DbCommand comProxy, string strDBKey)
        {
            DbConnection conProxy = this.Conectar(strDBKey);
            DbCommand cmdProxy = comProxy;

            DbDataAdapter adaProxy = this.CrearAdaptador();
            adaProxy.SelectCommand = cmdProxy;

            DataSet dtpProxy = new DataSet();
            adaProxy.Fill(dtpProxy);
            conProxy.Close();
            return dtpProxy;
        }
        public int EjecutarDML(string strDML, string strDBKey)
        {
            DbConnection conProxy = this.Conectar(strDBKey);
            DbCommand cmdProxy = this.CrearComando();
            cmdProxy.CommandText = strDML;
            cmdProxy.Connection = conProxy;
            conProxy.Close();
            return cmdProxy.ExecuteNonQuery();
        }
        public int EjecutarDML(DbCommand cmdProxy, string strDBKey)
        {
            DbConnection conProxy = this.Conectar(strDBKey);
            cmdProxy.Connection = conProxy;
            conProxy.Close();
            return cmdProxy.ExecuteNonQuery();
        }

        #region StoreProcedureopcional
        public DbParameter CrearParametros()
        {
            DbParameter parParametro = dpfProxy.CreateParameter();
            return parParametro;
        }
        public int EjecutarDML(string strDML, string strDBKey, List<DbParameter> lstParametros)
        {
            DbConnection conProxy = this.Conectar(strDBKey);
            DbCommand cmdProxy = this.CrearComando();
            cmdProxy.Connection = conProxy;
            cmdProxy.CommandText = strDML;
            cmdProxy.CommandType = CommandType.StoredProcedure;
            foreach (DbParameter lstParam in lstParametros)
            {
                cmdProxy.Parameters.Add(lstParam);
            }
            cmdProxy.ExecuteNonQuery();
            return Convert.ToInt32(cmdProxy.Parameters[0]);
        }
        public DataSet EjecutarConsulta(string strSelect, string strDBKey, List<DbParameter> lstParametro)
        {
            DbConnection conProxy = this.Conectar(strDBKey);
            DbCommand comProxy = this.CrearComando();
            comProxy.Connection = conProxy;
            comProxy.CommandText = strSelect;
            comProxy.CommandType = CommandType.StoredProcedure;
            DbDataAdapter adaProxy = this.CrearAdaptador();
            adaProxy.SelectCommand = comProxy;
            DataSet dtsProxy = new DataSet();
            foreach (DbParameter lstParam in lstParametro)
            {
                comProxy.Parameters.Add(lstParam);
            }
            adaProxy.Fill(dtsProxy);
            conProxy.Close();
            return dtsProxy;
        }
        #endregion
    }
}

