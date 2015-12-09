using SampleApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApplication.Models
{
    public class UserModel
    {
        private UserData _data;

        internal UserModel(UserData data)
        {
            _data = data;
        }

        internal UserData ToData()
        {
            return _data;
        }

        public int Id => _data.UserID;

        public string Name => _data.Name;

        public string Login => _data.Login;

        public string Password => _data.Password;
       
        public string Email => _data.Email;

        public string QQ => _data.QQ;

        public string Mobile => _data.Mobile;

        public string Role => _data.Role;

        public string Status => _data.Status;
    }
}