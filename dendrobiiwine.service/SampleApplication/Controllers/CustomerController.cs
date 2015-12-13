using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using SampleApplication.Base;
using SampleApplication.Business;
using SampleApplication.Data;
using SampleApplication.Models;
using SampleApplication.Util;

namespace SampleApplication.Controllers
{
    //[Module(AllowModules = Module.Vehicle | Module.Booking)]
    public class CustomerController : APIControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public APIActionResult.GeneralResult SendSMSCode(string mobile)
        {
            APIActionResult.GeneralResult result;
            
            var customer = CustomerBusiness.GetInstance().GetCustomerByMobileNo(mobile);
            if (customer == null)
            {
                result = new APIActionResult.GeneralResult {Success = false, Message = "手机号无法匹配到客户"};
            }
            else 
            {
                if (customer.GeneratedVerifyCodeTime.HasValue)
                {
                    result =
                        customer.GeneratedVerifyCodeTime.Value.AddMinutes(
                            TypeFormat.GetInt(ConfigSetting.VerifyCodeValidTime)) > DateTime.Now
                            ? new APIActionResult.GeneralResult {Success = false, Message = "验证码生成太频繁"}
                            : new APIActionResult.GeneralResult {Success = true, Message = "验证码已生成"};
                }
                else
                {
                    //generate verify code 
                    result = new APIActionResult.GeneralResult { Success = true, Message = "验证码已生成" };
                }
            }
            return result;
        }

        [HttpGet]
        [AllowAnonymous]
        public APIActionResult.LoginResult LoginBySMSCode(string mobile, string verifyCode)
        {
            APIActionResult.LoginResult result;

            //check moblie number format
            if (!CheckMobile(mobile))
            {
                result = new APIActionResult.LoginResult { Success = false, Message = "手机号码错误" };
            }
            else if (string.IsNullOrEmpty(verifyCode))
            {
                result = new APIActionResult.LoginResult { Success = false, Message = "验证码错误" };
            }
            else
            {
                var customer = CustomerBusiness.GetInstance().GetCustomerByMobileNo(mobile);
                if (customer == null)
                {
                    result = new APIActionResult.LoginResult { Success = false, Message = "手机号无法匹配到客户" };
                }
                else
                {
                    if (!customer.VerifyCode.Equals(verifyCode) ||
                        (customer.GeneratedVerifyCodeTime.HasValue && 
                        customer.GeneratedVerifyCodeTime.Value.AddMinutes(TypeFormat.GetInt(ConfigSetting.VerifyCodeValidTime)) < DateTime.Now))
                    {
                        result = new APIActionResult.LoginResult { Success = false, Message = "验证码错误" };
                    }
                    else
                    {
                        result = new APIActionResult.LoginResult
                        {
                            Success = true,
                            Message = "登录成功",
                            Content =
                                new APIActionResult.LoginInfo
                                {
                                    CustomerID = Encryption.Encrypt(customer.Id.ToString()),
                                    CustomerName = customer.Name
                                }
                        };
                    }
                }
            }
            return result;
        }

        private bool CheckMobile(string mobile)
        {
            //电信手机号正则:1[3578][01379]\d{8}
            //联通手机号正则:1[34578][01256]\d{8}
            //移动手机号正则:134[012345678]\d{7}|1[34578][012356789]\d{8}
            return Regex.IsMatch(mobile,
                @"^(1[3578][01379]\d{8}|1[34578][01256]\d{8}|134[012345678]\d{7}|1[34578][012356789]\d{8})$");
        }

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