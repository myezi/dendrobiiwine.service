using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApplication.Data
{
    public class CityData
    {
        public int CityID { get; set; }

        public int ProvinceID { get; set; }

        public string Name { get; set; }

        public string GroupCode { get; set; }

        public string Status { get; set; }
    }
}