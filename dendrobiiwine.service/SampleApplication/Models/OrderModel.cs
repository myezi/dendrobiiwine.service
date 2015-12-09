using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleApplication.Data;

namespace SampleApplication.Models
{
    public class OrderModel
    {
        private OrderData _data;

        internal OrderModel(OrderData data)
        {
            _data = data;
        }

        internal OrderData ToData()
        {
            return _data;
        }

        public int Id => _data.OrderInfoID;

        public int CustomerID => _data.CustomerID;

        public int ProviderID => _data.ProviderID;

        public int ServiceID => _data.ServiceID;

        public DateTime SubmitTime => _data.SubmitTime;

        public DateTime OrderTime => _data.OrderTime;

        public string Status => _data.OrderStatus;

        public string Comment => _data.Comments;
    }
}