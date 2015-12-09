using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApplication.Data
{
    public class CustomerData
    {
        public int CustomerID { get; set; } 
        public string Position { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string MemberCardNo { get; set; }
        public int CouponPoint { get; set; }
        public string Status { get; set; }
    }
}