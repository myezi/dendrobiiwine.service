using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using SampleApplication.Data;

namespace SampleApplication.Models
{
    public class ProviderModel
    {
        private ProviderData _data;

        internal ProviderModel(ProviderData data)
        {
            _data = data;
        }

        internal ProviderData ToData()
        {
            return _data;
        }

        public int Id => _data.ProviderID;

        public string Name => _data.Name;

        public string Type => _data.Type;

        public string Description => _data.Description;

        public string Province => _data.Province;

        public string City => _data.City;

        public string District => _data.District;

        public string Address => _data.Address;

        public string Phone => _data.Phone;

        //public string Login => _data.Login;

        //public string Password => _data.Password;

        public string BigImage => _data.BigImage;

        public string SmallImage => _data.SmallImage;

        public int Score => _data.Score;

        //public string Status => _data.Status;

    }
}