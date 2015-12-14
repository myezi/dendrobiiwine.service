using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApplication.Base
{
    public class APIActionResult
    {
        #region General Result

        public class GeneralResult
        {
            public bool Success { get; set; }

            public string Message { get; set; }
        }

        #endregion

        #region Login Result

        public class LoginResult : GeneralResult
        {
            public LoginInfo Content { get; set; }
        }

        public class LoginInfo
        {
            public string CustomerID { get; set; }
            public string CustomerName { get; set; }
        }

        #endregion

        #region Payment Result

        public class GeneratedPayCodeResult : GeneralResult
        {
            public string Content { get; set; }
        }

        public class PaymentResult : GeneralResult
        {
            public PaymentInfo Content { get; set; }
        }

        public class PaymentInfo
        {
            public string CustomerName { get; set; }
            public float Amount { get; set; }
        }

        #endregion
    }
}