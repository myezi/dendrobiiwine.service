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

        public string Id
        {
            get { return _data.USERID; }
        }

        public string Name
        {
            get { return _data.NAME; }
        }

        public string Login
        {
            get { return _data.LOGIN; }
        }
    }
}