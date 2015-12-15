using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleApplication.Data;

namespace SampleApplication.Models
{
    public class ProvinceModule
    {
        private ProvinceData _data;

        internal ProvinceModule(ProvinceData data)
        {
            _data = data;
        }

        internal ProvinceData ToData()
        {
            return _data;
        }

        public int Id => _data.ProvinceID;

        public string Name => _data.Name;

        public string GroupCode => _data.GroupCode;
    }
}