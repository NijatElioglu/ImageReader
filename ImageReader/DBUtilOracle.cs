using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ImageReader
{

    public class DBUtilOracle
    {
        private OracleConnection oraConnection;
        public string ConnectionString;

        public DBUtilOracle()
        {
            oraConnection = new OracleConnection();
            oraConnection.ConnectionString = "Data Source=dbmqs;Persist Security Info=True;User ID=A5DBMIGRATION;Password=9912018;";
            ConnectionString = oraConnection.ConnectionString;
        }

        public DataTable GetData(string sql, Array coll)
        {
            OracleCommand cmd = new OracleCommand(sql, oraConnection);
            if (coll != null && coll.Length > 0)
                cmd.Parameters.AddRange(coll);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            if (oraConnection.State != ConnectionState.Open)
            {
                oraConnection.Open();
            }
            da.Fill(dt);
            oraConnection.Close();

            return dt;
        }

        public int InsertUpdate(string sql, Array coll)
        {
            int result = 0;
            OracleCommand cmd = new OracleCommand(sql, oraConnection);
            if (coll != null && coll.Length > 0)
                cmd.Parameters.AddRange(coll);
            if (oraConnection.State != ConnectionState.Open)
            {
                oraConnection.Open();
            }
            result = cmd.ExecuteNonQuery();
            oraConnection.Close();

            return result;
        }
    }
}
