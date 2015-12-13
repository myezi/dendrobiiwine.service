using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleApplication.Data;

namespace SampleApplication.Models
{
    public class ServiceTypeModel
    {
        private ServiceTypeData _data;

        internal ServiceTypeModel(ServiceTypeData data)
        {
            _data = data;
        }

        internal ServiceTypeData ToData()
        {
            return _data;
        }

        public int ID => _data.ServiceTypeID;

        public string Name => _data.ServiceTypeName;
    }
}