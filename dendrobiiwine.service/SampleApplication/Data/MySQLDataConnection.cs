using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.Common;
using Dapper;

namespace SampleApplication.Data
{
    public class MySQLDataConnection
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["MYSQL"].ConnectionString;

        public static DbConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}