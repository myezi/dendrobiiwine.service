using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleApplication.Data;

namespace SampleApplication.Models
{
    public class CityModule
    {
        private CityData _data;

        internal CityModule(CityData data)
        {
            _data = data;
        }

        internal CityData ToData()
        {
            return _data;
        }

        public int Id => _data.CityID;
        
        public int ProvinceID => _data.ProvinceID;

        public string Name => _data.Name;

        public string GroupCode => _data.GroupCode;
    }
}