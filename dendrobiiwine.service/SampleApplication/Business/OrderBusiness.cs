using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SampleApplication.Base;
using SampleApplication.Data;
using SampleApplication.Models;

namespace SampleApplication.Business
{
    public class OrderBusiness : BusinessBase
    {
        private static OrderBusiness m_OrderBusiness = null;

        public static OrderBusiness GetInstance()
        {
            return m_OrderBusiness ?? (m_OrderBusiness = new OrderBusiness());
        }

        public async Task<OrderModel[]> GetOrderAsync()
        {
            string query = "select  * from orderinfo";
            var result = await MySQLDataHelp.GetData<OrderData>(query);
            return result.Select(d => new OrderModel(d)).ToArray();
        }

        public bool Create(OrderData aOrder)
        {
            string query =
                string.Format(
                    @"insert into orderinfo
                        (CustomerID, ProviderID, ServiceID, SubmitTime, OrderTime, OrderStatus, Comments)
                        value(@CustomerID, @ProviderID, @ServiceID, @SubmitTime, @OrderTime, @OrderStatus, @Comments)");
            return MySQLDataHelp.ExecuteSave(query, aOrder);
        }

        public bool Edit(OrderData aOrder)
        {
            string query =
                @"update orderinfo set CustomerID=@CustomerID, ProviderID=@ProviderID, ServiceID=@ServiceID, SubmitTime=@SubmitTime, 
                    OrderTime=@OrderTime, OrderStatus=@OrderStatus, Comments=@Comments where OrderInfoID=@OrderInfoID";
            return MySQLDataHelp.ExecuteSave(query, aOrder);
        }
    }
}