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
    }
}