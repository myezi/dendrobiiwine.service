using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApplication.Data
{
    public class OrderData
    {
        public int OrderInfoID { get; set; }
        public int CustomerID { get; set; }
        public int ProviderID { get; set; }
        public int ServiceID { get; set; }
        public DateTime SubmitTime { get; set; }
        public DateTime OrderTime { get; set; }
        public string OrderStatus { get; set; }
        public string Comments { get; set; }
    }
}