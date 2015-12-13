using SampleApplication.Data;
using SampleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SampleApplication.Base;

namespace SampleApplication.Business
{
    internal class UserBusiness : BusinessBase
    {

        private static UserBusiness m_UserBusiness = null;
        
        public static UserBusiness GetInstance()
        {
            return m_UserBusiness ?? (m_UserBusiness = new UserBusiness());
        }

        public async Task<UserModel[]> GetUsersAsync()
        {
            string query = "select  * from user";
            var result = await MySQLDataHelp.GetData<UserData>(query);
            return result.Select(d => new UserModel(d)).ToArray();
        }

        public bool Create(UserData aUser)
        {
            string query =
                string.Format(
                    @"insert into user 
                                (Name, Login, Password, Email, QQ, Mobile, Role, Status) 
                                value(@Name, @Login, @Password, @Email, @QQ, @Mobile, @Role, @Status)");
            return MySQLDataHelp.ExecuteSave(query, aUser);
        }

        public bool Edit(UserData aUser)
        {
            string query =
                @"update user set Name=@Name , Login=@Login, Password=@Password, Email=@Email , QQ=@QQ, Mobile=@Mobile, Role=@Role, Status=@Status where UserID=@UserID";
            return MySQLDataHelp.ExecuteSave(query, aUser);
        }
    }
}