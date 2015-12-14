using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using SampleApplication.Business;
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

        private ProviderData _providerData = null;

        private ProviderData ProviderData => _providerData ??
                                             (_providerData = ProviderBusiness.GetInstance().GetProviderDataByID(_data.ProviderID).Result);

        private ServiceData _serviceInfo = null;
        private ServiceData ServiceInfo
        {
            get
            {
                if (_serviceInfo == null)
                {
                    _serviceInfo = ServiceBusiness.GetInstance().GetServiceDataById(_data.ServiceID).Result;
                }
                return _serviceInfo;
            }
        }

        public int Id => _data.OrderInfoID;

        public int CustomerID => _data.CustomerID;

        public int ProviderID => _data.ProviderID;

        public string ProviderName => ProviderData.Name;

        public int ServiceID => _data.ServiceID;

        public string ServiceName => ServiceInfo.Name;

        public string ServiceSmallImage => ServiceInfo.SmallImage;

        public DateTime? SubmitTime => _data.SubmitTime;

        public DateTime? OrderTime => _data.OrderTime;

        public string Status => _data.OrderStatus;

        public string Comment => _data.Comments;
    }
}