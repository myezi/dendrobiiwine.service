using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace SampleApplication.Base
{
    public class EziWebApiExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var error = new HttpError(context.Exception,true) { };
            error.Message = context.Exception.Message;

            if (context.Exception is UnauthorizedAccessException)
            {
                //目前非500 Code无法在客户端报错.401错误只能隐藏到Error类内部
                //statusCode = HttpStatusCode.Unauthorized;
                error.Add("StatusCode", HttpStatusCode.Unauthorized);

            }
            else
            {
                error.Add("StatusCode", statusCode);

                //尝试把错误输出到EziException
            //    ILogger logger = context.Request.GetOwinContext().Get<ILogger>("EziException");
            //    if (logger != null)
            //    {
            //        logger.WriteCritical("WebApi Error at " + DateTime.Now.ToString(), context.Exception);
            //        logger.WriteVerbose("\r\n");
            //    }
            }
           
            //模拟ErrorModal,放入一个ErrorCode值.和前台获取错误统一
            context.Response = context.Request.CreateErrorResponse(statusCode, error);

            base.OnException(context);
        }
    }
}
