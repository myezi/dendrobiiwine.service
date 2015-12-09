using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApplication.Data
{
    public class PaymentData
    {
        public int PaymentID { get; set; }
        public int CustomerID { get; set; }
        public int ProviderID { get; set; }
        public int ServiceID { get; set; }
        public DateTime PayTime { get; set; }
        public int PayPoint { get; set; }
        public string PayStatus { get; set; }
        public string PayCardNo { get; set; }
    }
}