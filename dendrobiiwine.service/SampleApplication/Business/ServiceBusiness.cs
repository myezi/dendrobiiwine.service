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
    public class ServiceBusiness : BusinessBase
    {
        private static ServiceBusiness m_ServiceBusiness = null;

        public static ServiceBusiness GetInstance()
        {
            return m_ServiceBusiness ?? (m_ServiceBusiness = new ServiceBusiness());
        }

        public async Task<ServiceModel[]> GetServiceAsync()
        {
            string query = "select  * from service";
            var result = await MySQLDataHelp.GetData<ServiceData>(query);
            return result.Select(d => new ServiceModel(d)).ToArray();
        }

        public bool Create(ServiceData aServicer)
        {
            string query =
                string.Format(
                    @"insert into service
                        (ProviderID, Name, `Type`, Description, Count, BigImage, SmallImage, `Status`)
                        value(@ProviderID, @Name, @Type, @Description, @Count, @BigImage, @SmallImage, @Status)");
            return MySQLDataHelp.ExecuteSave(query, aServicer);
        }

        public bool Edit(ServiceData aServicer)
        {
            string query =
                @"update service set ProviderID=@ProviderID, Name=@Name, `Type`=@Type, Description=@Description, Count=@Count, 
                    BigImage=@BigImage, SmallImage=@SmallImage, `Status`=@Status where ServiceID=@ServiceID";
            return MySQLDataHelp.ExecuteSave(query, aServicer);
        }
    }
}