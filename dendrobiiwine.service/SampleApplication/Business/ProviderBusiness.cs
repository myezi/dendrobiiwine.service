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
    public class ProviderBusiness : BusinessBase
    {
        private static ProviderBusiness m_ProviderBusiness = null;

        public static ProviderBusiness GetInstance()
        {
            return m_ProviderBusiness ?? (m_ProviderBusiness = new ProviderBusiness());
        }

        public async Task<ProviderModel[]> GetProviderAsync()
        {
            string query = "select  * from provider";
            var result = await MySQLDataHelp.GetData<ProviderData>(query);
            return result.Select(d => new ProviderModel(d)).ToArray();
        }

        public async Task<ProviderModel[]> GetProvidersByAreaAsync(string area)
        {
            string query = "select * from provider";
            var result = await MySQLDataHelp.GetData<ProviderData>(query);
            return result.Select(d => new ProviderModel(d)).ToArray();
        }

        public async Task<ProviderModel> GetProviderByIDAsync(int id)
        {
            string query = string.Format("select  * from provider where ProviderID = {0}", id);
            var result = await MySQLDataHelp.GetData<ProviderData>(query);
            return new ProviderModel(result.First());
        }

        internal async Task<ProviderData> GetProviderDataByID(int id)
        {
            string query = string.Format("select  * from provider where ProviderID = {0}", id);
            var result = await MySQLDataHelp.GetData<ProviderData>(query);
            return result.First();
        }

        public bool Create(ProviderData aProvider)
        {
            string query =
                string.Format(
                    @"insert into provider
                        (Name, `Type`, Description, Province, City, District, Address, Phone, Login, Password, BigImage, SmallImage, Score, `Status`)
                        value(@Name, @Type, @Description, @Province, @City, @District, @Address, @Phone, @Login, @Password, @BigImage, @SmallImage, @Score, @Status)");
            return MySQLDataHelp.ExecuteSave(query, aProvider);
        }

        public bool Edit(ProviderData aProvider)
        {
            string query =
                @"update provider set Name=@Name, `Type`=@Type, Description=@Description, Province=@Province, City=@City, District=@District, 
                    Address=@Address, Phone=@Phone, Login=@Login, Password=@Password, BigImage=@BigImage, SmallImage=@SmallImage, Score=@Score, 
                    `Status`=@Status where ProviderID=@ProviderID";
            return MySQLDataHelp.ExecuteSave(query, aProvider);
        }
    }
}