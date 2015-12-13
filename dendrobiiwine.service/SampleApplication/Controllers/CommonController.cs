using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using SampleApplication.Base;
using SampleApplication.Business;
using SampleApplication.Models;

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
        public async Task<ProviderTypeModel[]> GetProviderTypes()
        {
            //return CommonBusiness.GetInstance().GetProviderType();
            return null;
        }

        [HttpGet]
        [AllowAnonymous]
        public void GetServiceTypes()
        {
        }
    }
}