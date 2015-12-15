using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SampleApplication.Base;
using SampleApplication.Data;
using SampleApplication.Models;

namespace SampleApplication.Business
{
    public class AreaBusiness : BusinessBase
    {
        private static AreaBusiness m_AreaBusiness = null;

        public static AreaBusiness GetInstance()
        {
            return m_AreaBusiness ?? (m_AreaBusiness = new AreaBusiness());
        }

        public async Task<ProvinceModule[]> GetActiveProvince()
        {
            string query = string.Format("select * from province where status = '{0}'",
                EnumConst.Status.Active.ToString());
            var result = await MySQLDataHelp.GetData<ProvinceData>(query);
            return result.Select(d => new ProvinceModule(d)).ToArray();
        }
        
        public async Task<CityModule[]> GetActiveCityByProvinceID(int provinceID)
        {
            string query = string.Format("select * from city where status = '{0}' and ProvinceID = {1}",
                EnumConst.Status.Active.ToString(), provinceID);
            var result = await MySQLDataHelp.GetData<CityData>(query);
            return result.Select(d => new CityModule(d)).ToArray();
        }

        public async Task<DistrictModule[]> GetActiveDistrictByCityID(int cityID)
        {
            string query = string.Format("select * from District where status = '{0}' and CityID = {1}",
                EnumConst.Status.Active.ToString(), cityID);
            var result = await MySQLDataHelp.GetData<DistrictData>(query);
            return result.Select(d => new DistrictModule(d)).ToArray();
        }

        public async Task<CityModule> GetCityByName(string name)
        {
            string query = string.Format("select * from city where name = '{0}'", name);
            var result = await MySQLDataHelp.GetData<CityData>(query);
            return new CityModule(result.First());
        }
    }
}