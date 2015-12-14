using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SampleApplication.Base;
using SampleApplication.Object;
using SampleApplication.Util;

namespace SampleApplication.Controllers
{
    public class PayController : APIControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public APIActionResult.GeneratedPayCodeResult GeneratePayCode(PaymentObject payment)
        {
            APIActionResult.GeneratedPayCodeResult result = new APIActionResult.GeneratedPayCodeResult { Success = false, Message = "请输入正确的Payment信息" };
            if (payment != null)
            {
                if (!string.IsNullOrEmpty(payment.CustomerID) && !string.IsNullOrEmpty(payment.Amount))
                {
                    var id = Encryption.Decrypt(payment.CustomerID);
                    var content =
                        Encryption.Encrypt(string.Format("{0};{1};{2}", id, payment.Amount,
                            DateTime.Now.AddMinutes(TypeFormat.GetInt(ConfigSetting.VerifyCodeValidTime)).ToString("yyyy-MM-dd HH:mm:ss")));
                    result = new APIActionResult.GeneratedPayCodeResult { Success = true, Message = "生成成功", Content = content};
                }
            }
            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        public void PreparePayment(string payCode)
        {
        }

        [HttpPost]
        [AllowAnonymous]
        public void MakePayment(string payCode)
        {
        }
    }
}