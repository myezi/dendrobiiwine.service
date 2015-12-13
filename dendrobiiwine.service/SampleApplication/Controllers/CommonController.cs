using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleApplication.Controllers
{
    public class CommonController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public void GetAreas()
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public void GetProviderTypes()
        {
        }

        [HttpGet]
        [AllowAnonymous]
        public void GetServiceTypes()
        {
        }
    }
}