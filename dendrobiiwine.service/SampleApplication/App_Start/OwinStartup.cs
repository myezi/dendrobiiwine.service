using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using SampleApplication.Base;

namespace SampleApplication
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        /// <summary>
        /// 加载MS Identy Owin组件
        /// </summary>
        /// <param name="app"></param>
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        private void ConfigureAuth(IAppBuilder app)
        {
            // 启用标准的Cookie登录
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = PathString.Empty // use empty becasue it's webapi only application
            });

            //启用外部登录
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            ////启用OAuth验证
            var OAuthOptions = new OAuthAuthorizationServerOptions
            {
                //获取Token的虚拟路径                
                TokenEndpointPath = new PathString("/Token"),
                Provider = new OAuthProvider("admin"), //默认的OAuth绑定用户为admin
                AuthorizeEndpointPath = PathString.Empty,
                ApplicationCanDisplayErrors = true,
                //Token 过期时间，默认1天               
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                //在生产模式下设 AllowInsecureHttp = false               
                AllowInsecureHttp = true
            };
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(
            //    clientId: "",
            //    clientSecret: "");
        }
    }
}