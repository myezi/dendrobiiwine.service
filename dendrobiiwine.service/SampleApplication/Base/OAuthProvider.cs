using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace SampleApplication.Base
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// 一个内部的用户Id,用于绑定所有通过Oauth进入的验证信息
        /// </summary>
        private string _publicIdentity;

        public OAuthProvider(string publicId)
        {
            _publicIdentity = publicId;
        }

        /// <summary>
        /// 通过传递标准的clientId和clientSecret来获取Token.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //获取客户端传递的标准的clientId和clientSecret
            string clientId, clientSecret;
            context.TryGetBasicCredentials(out clientId, out clientSecret);
            //这里可以加入验证clientId和clientSecret是否合法的代码
            if (clientId == _publicIdentity && clientSecret=="123")
            {
                context.Validated();
            }
            return Task.FromResult(0);
        }

        /// <summary>
        /// 当Tocken通过验证以后,以系统的一个_publicIdentity登录进入系统.
        /// 登录成功以后,所有Authorize的WebApi都可以继续访问.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            oAuthIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, _publicIdentity));//User id
            oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, _publicIdentity));//User name
            var ticket = new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties());
            context.Validated(ticket);
            return base.GrantClientCredentials(context);
        }
    }
}