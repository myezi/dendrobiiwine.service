using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Submail.AppConfig;
using Submail.Lib;

namespace SampleApplication.Base
{
    public class SendSMSBusiness
    {
        public static void SendMessage(string sendTo, string messageID, Dictionary<string, string> messageValue)
        {
            IAppConfig appConfig = new MessageConfig(ConfigSetting.SMSAppID, ConfigSetting.SMSAppKey);
            MessageXSend messageXSend = new MessageXSend(appConfig);
            messageXSend.AddTo(sendTo);
            messageXSend.SetProject(messageID);
            //messageXSend.AddVar("code", "123456");
            //messageXSend.AddVar("number", "Nick.Yang");
            foreach (var v in messageValue)
            {
                messageXSend.AddVar(v.Key, v.Value);
            }
            string returnMessage = string.Empty;
            if (messageXSend.XSend(out returnMessage) == false)
            {
                Console.WriteLine(returnMessage);
            }
        }

        public static void SendMultiMessage(List<string> sendTo, string messageID, Dictionary<string, string> messageValue)
        {
            IAppConfig appConfig = new MessageConfig(ConfigSetting.SMSAppID, ConfigSetting.SMSAppKey);
            MessageMultiXSend messageMultiSend = new MessageMultiXSend(appConfig);
            messageMultiSend.SetProject(messageID);

            Dictionary<string, string> vars = messageValue.ToDictionary(v => v.Key, v => v.Value);
            //vars.Add("code", "123456");
            //vars.Add("number", "Nick.Yang");
            messageMultiSend.SetMulti(sendTo.Select(to => new MultiMessageItem() { to = to, vars = vars }).ToList());

            string returnMessage = string.Empty;
            if (messageMultiSend.MultiXSend(out returnMessage) == false)
            {
                Console.WriteLine(returnMessage);
            }
        }
    }
}