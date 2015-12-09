using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleApplication.Data;

namespace SampleApplication.Models
{
    public class PaymentModel
    {
        private PaymentData _data;

        internal PaymentModel(PaymentData data)
        {
            _data = data;
        }

        internal PaymentData ToData()
        {
            return _data;
        }

        public int Id => _data.PaymentID;

        public int CustomerID => _data.CustomerID;

        public int ProviderID => _data.ProviderID;

        public int ServiceID => _data.ServiceID;

        public DateTime PayTime => _data.PayTime;

        public int PayPoint => _data.PayPoint;

        public string Status => _data.PayStatus;

        public string PayCardNo => _data.PayCardNo;
    }
}