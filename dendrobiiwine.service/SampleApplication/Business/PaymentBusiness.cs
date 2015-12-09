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
    public class PaymentBusiness : BusinessBase
    {
        private static PaymentBusiness m_PaymentBusiness = null;

        public static PaymentBusiness GetInstance()
        {
            return m_PaymentBusiness ?? (m_PaymentBusiness = new PaymentBusiness());
        }

        public async Task<PaymentModel[]> GetPaymentAsync()
        {
            string query = "select  * from payment";
            var result = await MySQLDataHelp.GetData<PaymentData>(query);
            return result.Select(d => new PaymentModel(d)).ToArray();
        }

        public bool Create(PaymentData aPayment)
        {
            string query =
                string.Format(
                    @"insert into payment
                        (CustomerID, ProviderID, ServiceID, PayTime, PayPoint, PayStatus, PayCardNo)
                        value(@CustomerID, @ProviderID, @ServiceID, @PayTime, @PayPoint, @PayStatus, @PayCardNo)");
            return MySQLDataHelp.ExecuteSave(query, aPayment);
        }

        public bool Edit(PaymentData aPayment)
        {
            string query =
                @"update payment set CustomerID=@CustomerID, ProviderID=@ProviderID, ServiceID=@ServiceID, PayTime=@PayTime, 
                    PayPoint=@PayPoint, PayStatus=@PayStatus, PayCardNo=@PayCardNo where PaymentID=@PaymentID";
            return MySQLDataHelp.ExecuteSave(query, aPayment);
        }
    }
}