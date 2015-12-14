using SampleApplication.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Linq;
using SampleApplication.Business;
using SampleApplication.Base;

namespace SampleApplication.Controllers
{
    [EnableCors]
    public class DefaultController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public string Hello()
        {
            return "Hello";
        }

        [HttpGet]
        [AllowAnonymous]
        public string Encrypt(string id)
        {
            return "通过DES加密后的内容是: " + Encryption.Encrypt(id);
        }

        [HttpGet]
        [AllowAnonymous]
        public string Decrypt(string content)
        {
            return "通过DES解密后的内容是: " + Encryption.Decrypt(content);
        }
          
        /// <summary>
        /// 生成指定数量卡号
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public object[] GenerateCards(int quantity)
        {
            return GenerateCardBusiness.GetInstance().GenerateCardNo(quantity);
        }

        [HttpGet]
        [AllowAnonymous]
        public object GetAppInfo()
        {
            return new
            {
                Name = "测试WebApi",
                CompanyName = "内部测试部门"
            };
        }

    }
}
