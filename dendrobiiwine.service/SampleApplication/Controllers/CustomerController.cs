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
    public class CustomerController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<CustomerModel[]> GetCustomer()
        {
            return await CustomerBusiness.GetInstance().GetCustomerAsync();
        }

        [HttpPost]
        public bool Save(CustomerModel customer)
        {
            var aCustomer = new CustomerData()
            {
                CustomerID = customer.Id,
                Position = customer.Position,
                Name = customer.Name,
                Company = customer.Company,
                Province = customer.Province,
                City = customer.City,
                District = customer.District,
                Address = customer.Address,
                Mobile = customer.Mobile,
                MemberCardNo = customer.MemberCardNo,
                CouponPoint = customer.CouponPoint,
                Status = customer.Status
            };

            return aCustomer.CustomerID == 0
                ? CustomerBusiness.GetInstance().Create(aCustomer)
                : CustomerBusiness.GetInstance().Edit(aCustomer);
        }
    }
}