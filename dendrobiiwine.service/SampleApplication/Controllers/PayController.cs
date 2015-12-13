using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleApplication.Controllers
{
    public class PayController : Controller
    {
        [HttpPost]
        [AllowAnonymous]
        public void GeneratePayCode()
        {
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