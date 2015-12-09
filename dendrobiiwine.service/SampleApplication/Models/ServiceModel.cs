using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleApplication.Data;

namespace SampleApplication.Models
{
    public class ServiceModel
    {
        private ServiceData _data;

        internal ServiceModel(ServiceData data)
        {
            _data = data;
        }

        internal ServiceData ToData()
        {
            return _data;
        }

        public int Id => _data.ServiceID;

        public int ProviderID => _data.ProviderID;

        public string Name => _data.Name;

        public string Type => _data.Type;

        public string Description => _data.Description;

        public int Count => _data.Count;

        public string BigImage => _data.BigImage;

        public string SmallImage => _data.SmallImage;

        public string Status => _data.Status;
    }
}