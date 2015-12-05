using SampleApplication.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Linq;

namespace SampleApplication.Controllers
{
   
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

        const string CARD_PREFIX = "6088";
        const string DEFAULT_AREA_CODE = "0523";
  
        /// <summary>
        /// 为泰州生成1000个卡号
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public object[] GenerateCards()
        {
            var rand = new Random();
            var cardNoList = new List<string>();

            while(cardNoList.Count < 1000)
            {
                var randNo = rand.Next(10000000, 100000000);
                var cardNo = CARD_PREFIX + DEFAULT_AREA_CODE + randNo;
                if (!cardNoList.Contains(cardNo))
                {
                    cardNoList.Add(cardNo);
                }
            }

            return cardNoList.Select(c => new { No = c, Key = Encryption.Encrypt(c) }).ToArray();
        }


    }
}
