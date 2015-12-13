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
    public class CommonBusiness : BusinessBase
    {
        private static CommonBusiness m_CommonBusiness = null;

        public static CommonBusiness GetInstance()
        {
            return m_CommonBusiness ?? (m_CommonBusiness = new CommonBusiness());
        }

        public async Task<ProviderTypeModel[]> GetProviderType(string status)
        {
            string query = "select * from ProviderType";
            if (!string.IsNullOrEmpty(status))
            {
                query += string.Format(" where Status = '{0}'", status);
            }
            var result = await MySQLDataHelp.GetData<ProviderTypeData>(query);
            return result.Select(d => new ProviderTypeModel(d)).ToArray();
        }

        public async Task<ServiceTypeModel[]> GetServiceType(string status)
        {
            string query = "select * from ServiceType";
            if (!string.IsNullOrEmpty(status))
            {
                query += string.Format(" where Status = '{0}'", status);
            }
            var result = await MySQLDataHelp.GetData<ServiceTypeData>(query);
            return result.Select(d => new ServiceTypeModel(d)).ToArray();
        }
    }
}