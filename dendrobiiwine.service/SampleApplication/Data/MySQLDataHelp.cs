using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Web;
using Dapper;

namespace SampleApplication.Data
{
    public class MySQLDataHelp
    {
        public static async Task<List<T>> GetData<T>(string query)
        {
            using (var conn = MySQLDataConnection.OpenConnection())
            {
                var result = await conn.QueryAsync<T>(query);
                return result.ToList();
            }
        }

        public static bool ExecuteSave<T>(string query, T value)
        {
            using (var conn = MySQLDataConnection.OpenConnection())
            {
                conn.Execute(query, value);
                return true;
            }
        }
    }
}