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
    public class PaymentController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<PaymentModel[]> Getpayment()
        {
            return await PaymentBusiness.GetInstance().GetPaymentAsync();
        }

        [HttpPost]
        public bool Save(PaymentModel payment)
        {
            var aPayment = new PaymentData
            {
                PaymentID = payment.Id,
                CustomerID = payment.CustomerID,
                ProviderID = payment.ProviderID,
                ServiceID = payment.ServiceID,
                PayTime = payment.PayTime,
                PayPoint = payment.PayPoint,
                PayStatus = payment.Status,
                PayCardNo = payment.PayCardNo
            };

            return aPayment.PaymentID == 0
                ? PaymentBusiness.GetInstance().Create(aPayment)
                : PaymentBusiness.GetInstance().Edit(aPayment);
        }
    }
}