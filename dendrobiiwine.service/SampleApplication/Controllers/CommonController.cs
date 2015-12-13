using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SampleApplication.Base;

namespace SampleApplication.Controllers
{
    public class CommonController : APIControllerBase
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