using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace SampleApplication.Data
{
    public class SQLDataConnection
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["MSSQL"].ConnectionString;

        public static DbConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}