using System.Linq;
using System.Web.Http.Filters;

namespace SampleApplication.Base
{
    public class EnableCorsAttribute : ActionFilterAttribute
    {
        const string Origin = "Origin";
        const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
        const string AccessControlAllowCredentials = "Access-Control-Allow-Credentials";

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Request.Headers.Contains(Origin))
            {
                string originHeader = actionExecutedContext.Request.Headers.GetValues(Origin).FirstOrDefault();
                if (!string.IsNullOrEmpty(originHeader))
                {
                    actionExecutedContext.Response.Headers.Add(AccessControlAllowOrigin, originHeader);
                    //在Ajax中加入参数xhrFields : { withCredentials: true} 必须HTTP头
                    actionExecutedContext.Response.Headers.Add(AccessControlAllowCredentials, "true");
                }
            }
        }
    }
}