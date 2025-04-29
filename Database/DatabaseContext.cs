using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace BTL_nhom11_marketPC.Database
{
    class DatabaseContext
    {
        private static SqlConnection conn;

        private static string connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=TenCSDL;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            if (conn == null || conn.State == System.Data.ConnectionState.Closed)
            {
                conn = new SqlConnection(connStr);
                conn.Open();
            }
            return conn;
        }

        public static void CloseConnection()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
    }
}
