using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SampleApplication.Base;
using SampleApplication.Business;
using SampleApplication.Data;
using SampleApplication.Models;

namespace SampleApplication.Controllers
{
    public class ServiceController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ServiceModel[]> GetUsers()
        {
            return await ServiceBusiness.GetInstance().GetServiceAsync();
        }

        [HttpPost]
        public bool Save(ServiceModel service)
        {
            var aService = new ServiceData
            {
                ServiceID = service.Id,
                ProviderID = service.ProviderID,
                Name = service.Name,
                Type = service.Type,
                Description = service.Description,
                Count = service.Count,
                BigImage = service.BigImage,
                SmallImage = service.SmallImage,
                Status = service.Status
            };

            return aService.ServiceID == 0
                ? ServiceBusiness.GetInstance().Create(aService)
                : ServiceBusiness.GetInstance().Edit(aService);
        }
    }
}