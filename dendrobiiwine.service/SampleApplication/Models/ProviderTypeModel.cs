using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleApplication.Data;

namespace SampleApplication.Models
{
    public class ProviderTypeModel
    {
        private ProviderTypeData _data;

        internal ProviderTypeModel(ProviderTypeData data)
        {
            _data = data;
        }

        internal ProviderTypeData ToData()
        {
            return _data;
        }

        public int ID => _data.ProviderTypeID;

        public string Name => _data.ProviderTypeName;
    }
}