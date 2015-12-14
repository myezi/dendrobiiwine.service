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
    public class OrderController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<OrderModel[]> GetOrder()
        { 
            return await OrderBusiness.GetInstance().GetOrderAsync();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<OrderModel[]> GetPendingOrdersByCustomerId(string id)
        {
            return await OrderBusiness.GetInstance().GetPendingOrdersByCustomerIdAsync(id, string.Empty, string.Empty);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<OrderModel[]> GetHistoryOrdersInPeriod(string id, string startDate, string endDate)
        {
            return await OrderBusiness.GetInstance().GetPendingOrdersByCustomerIdAsync(id, startDate, endDate);
        }

        [HttpPost]
        [AllowAnonymous]
        public APIActionResult.GeneralResult MakeOrder(OrderModel order)
        {
            try
            {
                var aOrder = new OrderData
                {
                    OrderInfoID = order.Id,
                    CustomerID = order.CustomerID,
                    ProviderID = order.ProviderID,
                    ServiceID = order.ServiceID,
                    SubmitTime = TypeFormat.GetDateTime(order.SubmitTime),
                    OrderTime = TypeFormat.GetDateTime(order.OrderTime),
                    OrderStatus = order.Status,
                    Comments = order.Comment
                };

                bool isSuccess = aOrder.OrderInfoID == 0
                    ? OrderBusiness.GetInstance().Create(aOrder)
                    : OrderBusiness.GetInstance().Edit(aOrder);
                return new APIActionResult.GeneralResult {Success = isSuccess, Message = "保存成功"};
            }
            catch (Exception ex)
            {
                return new APIActionResult.GeneralResult { Success = false, Message = ex.Message };
            }
        }
    }
}