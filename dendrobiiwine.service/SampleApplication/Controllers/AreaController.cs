using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SampleApplication.Base;
using SampleApplication.Business;
using SampleApplication.Models;

namespace SampleApplication.Controllers
{
    public class AreaController : APIControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ProvinceModule[]> GetProvince()
        {
            return await AreaBusiness.GetInstance().GetActiveProvince();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<CityModule[]> GetCityByProvinceID(string provinceID)
        {
            return await AreaBusiness.GetInstance().GetActiveCityByProvinceID(TypeFormat.GetInt(provinceID));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<DistrictModule[]> GetDistrictByCityID(string cityID)
        {
            return await AreaBusiness.GetInstance().GetActiveDistrictByCityID(TypeFormat.GetInt(cityID));
        }
    }
}
