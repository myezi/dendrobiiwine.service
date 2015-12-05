using Dapper;
using SampleApplication.Base;
using SampleApplication.Data;
using SampleApplication.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SampleApplication.Business
{
    public class GenerateCardBusiness : BusinessBase
    {
        private static GenerateCardBusiness m_GenerateCardBusiness = null;

        const string CARD_PREFIX = "6088";
        const string DEFAULT_AREA_CODE = "0523";

        public static GenerateCardBusiness GetInstance()
        {
            return m_GenerateCardBusiness ?? (m_GenerateCardBusiness = new GenerateCardBusiness());
        }

        /// <summary>
        /// 生成卡号和二维码号
        /// </summary>
        /// <param name="quantity">需要生成卡号数量</param>
        /// <returns></returns>
        public object[] GenerateCardNo(int quantity)
        {
            var existsCardNo = GetExistsCardNo();

            var rand = new Random();
            var cardNoList = new List<VipCardData>();

            while (cardNoList.Count < quantity)
            {
                var randNo = rand.Next(10000000, 100000000);
                var cardNo = CARD_PREFIX + DEFAULT_AREA_CODE + randNo;
                if (existsCardNo.All(c => c.VipNumber != cardNo))
                {
                    var vipCard = new VipCardData { VipNumber = cardNo, VipKey = Encryption.Encrypt(cardNo), IsAssigned = "N" };
                    AddCardNo(vipCard);
                    cardNoList.Add(vipCard);
                }                
            }

            return cardNoList.Select(c => new { No = c.VipNumber, Key = c.VipKey }).ToArray();
        }

        private List<VipCardData> GetExistsCardNo()
        {
            using (var conn = MySQLDataConnection.OpenConnection())
            {
                const string query = "select * from VIPCard";
                var result = conn.Query<VipCardData>(query);
                return result.ToList();
            }
        }

        private void AddCardNo(VipCardData aCard)
        {
            using (var conn = MySQLDataConnection.OpenConnection())
            {
                string query = string.Format(@"insert into vipcard
                                (VIPNumber, VIPKey, IsAssigned)
                                value(@VIPNumber, @VIPKey, @IsAssigned)");
                conn.Execute(query, aCard);
            }
        }
    }
}