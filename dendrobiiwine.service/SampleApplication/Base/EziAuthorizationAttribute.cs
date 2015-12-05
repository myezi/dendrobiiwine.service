using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http;

namespace SampleApplication.Base
{
    public class EziAuthorizationAttribute : AuthorizationFilterAttribute
    {
     
        private string _message;

        public EziAuthorizationAttribute()
        {
            _message = ""; 
        }


        /// <summary>
        /// 在HTTP Header里面Token的名称
        /// </summary>
        private const string TOKEN_NAME = "token";
  
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //当存在AllowAnonymousAttribute的Action,不需要进行身份校验
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Count == 0)
            {
                //处理Header的token验证,token验证可以让外部访问在一定的安全机制保护下,直接进入内部验证.
                var token = "";
                IEnumerable<string> tokens;
                if (actionContext.Request.Headers.TryGetValues(TOKEN_NAME, out tokens))
                {
                    token = tokens.FirstOrDefault();
                }

                var currentModule = (Module)int.Parse(token.Split(',')[0]);

                var moduleAttrs = actionContext.ActionDescriptor.GetCustomAttributes<ModuleAttribute>();
                if (moduleAttrs.Count == 0)
                    moduleAttrs = actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<ModuleAttribute>();

                if (moduleAttrs.Count > 0)
                {
                    if ((moduleAttrs[0].AllowModules | currentModule) == 0)
                        throw new UnauthorizedAccessException(_message);
                }
            }

            base.OnAuthorization(actionContext);
        }

        /// <summary>
        /// 通过Token验证机制
        /// Token字符串的规则为 允许加入User,Role和Rights的定义,但只能允许一个.根据需要加入Expiry(过期时间,以Tick时间记录)
        /// 范例: Expiry:122123123;User:user;Role:admin;Rights:a100
        /// User,Role,Rights任有一个就行,如果都没有验证失败.
        /// Expiry如果没有,认为无时间限制.
        /// </summary>
        /// <param name="tokenStr">为加密字符串,解密如果失败,认为验证失败</param>
        /// <returns></returns>
        private bool TryCheckToken(string tokenStr)
        {
            bool result = true;
            return result;
        }

    }
}
