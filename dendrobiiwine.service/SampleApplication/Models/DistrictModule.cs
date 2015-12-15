using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleApplication.Data;

namespace SampleApplication.Models
{
    public class DistrictModule
    {
        private DistrictData _data;

        internal DistrictModule(DistrictData data)
        {
            _data = data;
        }

        internal DistrictData ToData()
        {
            return _data;
        }

        public int Id => _data.DistrictID;

        public int CityID => _data.CityID;

        public string Name => _data.Name;

        public string GroupCode => _data.GroupCode;
    }
}