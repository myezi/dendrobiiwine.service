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
    [Module(AllowModules = Module.Vehicle | Module.Booking)]
    public class ProviderController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ProviderModel[]> GetProvidersByArea(string area)
        {
            return await ProviderBusiness.GetInstance().GetProvidersByAreaAsync(area);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ProviderModel> GetProviderDetailById(int id)
        {
            return await ProviderBusiness.GetInstance().GetProviderByIDAsync(id);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ServiceModel[]> GetServicesByProviderID(int id)
        {
            return await ServiceBusiness.GetInstance().GetServicesByProviderIDAsync(id);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ServiceModel> GetServiceDetailByID(int id)
        {
            return await ServiceBusiness.GetInstance().GetServiceByIDAsync(id);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ProviderModel[]> GetProvider()
        {
            return await ProviderBusiness.GetInstance().GetProviderAsync();
        }

        [HttpPost]
        public bool Save(ProviderModel provider)
        {
            var aProvider = new ProviderData
            {
                ProviderID = provider.Id,
                Name = provider.Name,
                Type = provider.Type,
                Description = provider.Description,
                Province = provider.Province,
                City = provider.City,
                District = provider.District,
                Address = provider.Address,
                Phone = provider.Phone,
                //Login = provider.Login,
                //Password = provider.Password,
                BigImage = provider.BigImage,
                SmallImage = provider.SmallImage,
                Score = provider.Score,
                //Status = provider.Status
            };

            return aProvider.ProviderID == 0
                ? ProviderBusiness.GetInstance().Create(aProvider)
                : ProviderBusiness.GetInstance().Edit(aProvider);
        }
    }
}