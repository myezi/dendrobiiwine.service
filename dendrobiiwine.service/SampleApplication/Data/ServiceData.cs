using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApplication.Data
{
    public class ServiceData
    {
        public int ServiceID { get; set; }
        public int ProviderID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public string BigImage { get; set; }
        public string SmallImage { get; set; }
        public string Status { get; set; }
    }
}