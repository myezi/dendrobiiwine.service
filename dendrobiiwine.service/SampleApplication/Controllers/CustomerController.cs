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
                            TypeFormat.GetInt(ConfigSetting.VerifyCodeValidTime)) < DateTime.Now
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

        [HttpPost]
        [AllowAnonymous]
        public APIActionResult.LoginResult LoginBySMSCode(LoginModel login)
        {
            APIActionResult.LoginResult result;

            if (login != null)
            {
                //check moblie number format
                if (!Regex.IsMatch(login.MobileNumber, "/^(0|86|17951)?(13[0-9]|15[012356789]|17[678]|18[0-9]|14[57])[0-9]{8}$/"))
                {
                    result = new APIActionResult.LoginResult { Success = false, Message = "手机号码错误" };
                }
                else if (string.IsNullOrEmpty(login.VerifyCode))
                {
                    result = new APIActionResult.LoginResult { Success = false, Message = "验证码错误" };
                }
                else
                {
                    var customer = CustomerBusiness.GetInstance().GetCustomerByMobileNo(login.MobileNumber);
                    if (customer == null)
                    {
                        result = new APIActionResult.LoginResult { Success = false, Message = "手机号无法匹配到客户" };
                    }
                    else
                    {
                        if (!customer.VerifyCode.Equals(login.VerifyCode) ||
                            (customer.GeneratedVerifyCodeTime.HasValue && 
                            customer.GeneratedVerifyCodeTime.Value.AddMinutes(TypeFormat.GetInt(ConfigSetting.VerifyCodeValidTime)) > DateTime.Now))
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
            }
            else
            {
                result = new APIActionResult.LoginResult { Success = false, Message = "请正确输入手机号码和验证码" };
            }
            return result;
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