using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleApplication.Data;

namespace SampleApplication.Models
{
    public class CustomerModel
    {
        private CustomerData _data;

        internal CustomerModel(CustomerData data)
        {
            _data = data;
        }

        internal CustomerData ToData()
        {
            return _data;
        }

        public int Id => _data.CustomerID;

        public string Position => _data.Position;

        public string Name => _data.Name;

        public string Company => _data.Company;
        
        public string Province => _data.Company;

        public string City => _data.City;

        public string District => _data.District;

        public string Address => _data.Address;

        public string Mobile => _data.Mobile;

        public string MemberCardNo => _data.MemberCardNo;

        public int CouponPoint => _data.CouponPoint;

        public string Status => _data.Status;
    }
}