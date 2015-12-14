using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SampleApplication.Base
{
    public class ConfigSetting
    {
        public static readonly string VerifyCodeValidTime = ConfigurationManager.AppSettings["VerifyCodeValidTime"];

        public static readonly string SMSAppID = ConfigurationManager.AppSettings["SMSAppID"];

        public static readonly string SMSAppKey = ConfigurationManager.AppSettings["SMSAppKey"];
    }
}