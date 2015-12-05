using SampleApplication.Data;
using SampleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace SampleApplication.Business
{
    internal class UserManager
    {
        public static async Task<UserModel[]> GetUsersAsync()
        {
            using (var conn = MySQLDataConnection.OpenConnection())
            {
                const string query = "select  * from users limit 0,100";
                var result = await conn.QueryAsync<UserData>(query);
                return result.Select(d => new UserModel(d)).ToArray();
            }
        }

        public static UserModel[] GetUsers()
        {
            using (var conn = MySQLDataConnection.OpenConnection())
            {
                const string query = "select  * from users limit 0,100";
                var result = conn.Query<UserData>(query);
                return result.Select(d => new UserModel(d)).ToArray();
            }
        }
    }
}