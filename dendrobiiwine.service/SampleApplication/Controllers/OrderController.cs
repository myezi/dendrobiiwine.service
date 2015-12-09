using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SampleApplication.Base;
using SampleApplication.Business;
using SampleApplication.Data;
using SampleApplication.Models;

namespace SampleApplication.Controllers
{
    [Module(AllowModules = Module.Vehicle | Module.Booking)]
    public class OrderController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<OrderModel[]> GetOrder()
        { 
            return await OrderBusiness.GetInstance().GetOrderAsync();
        }

        [HttpPost]
        public bool Save(OrderModel order)
        {
            var aOrder = new OrderData
            {
                OrderInfoID = order.Id,
                CustomerID = order.CustomerID,
                ProviderID = order.ProviderID,
                ServiceID = order.ServiceID,
                SubmitTime = order.SubmitTime,
                OrderTime = order.OrderTime,
                OrderStatus = order.Status,
                Comments = order.Comment
            };

            return aOrder.OrderInfoID == 0
                ? OrderBusiness.GetInstance().Create(aOrder)
                : OrderBusiness.GetInstance().Edit(aOrder);
        }
    }
}