using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace Obdz1
{
    public class DB
    {
        public OracleTransaction tr;
        public string connectionString = "Data Source=xe;User ID=system; Password=wtfwtf;";
        public OracleConnection connection;
        public DataTable dt;
        bool b;
        public DB()
        {
            Connect();
        }
        private void Connect()
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
            }
            catch
            {
                MessageBox.Show("Cannot connect to database");
            }
        }
        public DataTable ConnectData(string sql, string tab)
        {
            Connect();
            OracleTransaction tr = connection.BeginTransaction();
            try
            {
                OracleCommand command = new OracleCommand(sql, connection);
                b = false;
                command.Transaction = tr;
                OracleDataAdapter da = new OracleDataAdapter(command);
                dt = new DataTable(tab);
                //string s=da.ToString();
                da.Fill(dt);
                //  OracleCommandBuilder builder = new OracleCommandBuilder(da);
                // builder.GetUpdateCommand();
                //  builder.GetDeleteCommand();
                //  builder.GetInsertCommand();
            }
            catch
            {
                MessageBox.Show("Cannot apply data to table");
                tr.Rollback();
                b = true;
            }
            finally
            {
                //MessageBox.Show("Transaction complited...");
           
                    tr.Commit();
                connection.Close();
            }
            return dt;
        }
        public void SqlExecute(string sql, bool isfunc /*,string date,float value*/)
        {
            Connect();
            b = false;
            OracleTransaction tr = connection.BeginTransaction();
            try
            {
                OracleCommand command = new OracleCommand(sql, connection);
                command.Transaction = tr;
                if (isfunc)
                    command.CommandType = CommandType.StoredProcedure;

                command.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                MessageBox.Show(e.Message);
                tr.Rollback();
                b = true;
            }
            finally
            {
                //MessageBox.Show("Transaction complited...");
           
                    tr.Commit();
                connection.Close();
            }
        }
        public void getChange(DataTable table)
        {
            OracleDataAdapter da = new OracleDataAdapter();
            da.Update(table);
        }
    }
}
/*OracleParameter datepar = new OracleParameter();
datepar.DbType = DbType.DateTime;
datepar.Value = DateTime.Parse(date);
datepar.ParameterName = "datepar";

OracleParameter valuepar = new OracleParameter();
valuepar.Value = value;
valuepar.ParameterName = "valuepar";
command.Parameters.Add(datepar);
command.Parameters.Add(valuepar);*/