using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleApplication.Base;
using System.Threading.Tasks;
using Dapper;
using SampleApplication.Data;
using SampleApplication.Models;

namespace SampleApplication.Business
{
    public class CustomerBusiness : BusinessBase
    {
        private static CustomerBusiness m_CustomerBusiness = null;

        public static CustomerBusiness GetInstance()
        {
            return m_CustomerBusiness ?? (m_CustomerBusiness = new CustomerBusiness());
        }

        public async Task<CustomerModel[]> GetCustomerAsync()
        {
            string query = "select * from customer";
            var result = await MySQLDataHelp.GetData<CustomerData>(query);
            return result.Select(d => new CustomerModel(d)).ToArray();
        }

        public CustomerModel GetCustomerByMobileNo(string mobileNo)
        {
            string query = string.Format(@"select * from customer where Mobile = '{0}'", mobileNo);
            var result = MySQLDataHelp.GetData<CustomerData>(query);
            return result.Result.Select(d => new CustomerModel(d)).First();
        }

        public bool Create(CustomerData aCustomerData)
        {
            string query =
                string.Format(
                    @"insert into customer
                        (Position, Name, Company, Province, City, District, Address, Mobile, MemberCardNo, CouponPoint, Status)
                        value(@Position, @Name, @Company, @Province, @City, @District, @Address, @Mobile, @MemberCardNo, @CouponPoint, @Status)");
            return MySQLDataHelp.ExecuteSave(query, aCustomerData);
        }

        public bool Edit(CustomerData aCustomerData)
        {
            string query =
                @"update customer set POSITION=@POSITION, Name=@Name, Company=@Company, Province=@Province, City=@City, District=@District, 
                    Address=@Address, Mobile=@Mobile, MemberCardNo=@MemberCardNo, CouponPoint=@CouponPoint, Status=@Status where CustomerID=@CustomerID";
            return MySQLDataHelp.ExecuteSave(query, aCustomerData);
        }
    }
}