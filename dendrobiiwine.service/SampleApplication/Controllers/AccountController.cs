using Microsoft.Owin.Security;
using SampleApplication.Base;
using SampleApplication.Models;
using System.Web.Http;
using Newtonsoft.Json;
using System.IO;
using System;
using SampleApplication.Util;
using System.Net.Http;
using SampleApplication.Business;
using Microsoft.AspNet.Identity;

namespace SampleApplication.Controllers
{
    [EnableCors]
    /// <summary>
    /// 处理登录相关事宜的WebApi控制类
    /// </summary>
    public class AccountController : ApiController
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return Request.GetOwinContext().Authentication;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public ResultModel Login(LoginViewModel login)
        {
            if (login.name == "admin")
            {
                var admin = new IdentityUser
                {
                    Id = "admin",
                    UserName = "admin",
                    Email = "admin@app.com",
                    Roles = new string[] { "admin" }
                };
                AuthenticationManager.SignIn(admin.GenerateUserIdentity());
                return new ResultModel { status = true };
            }
            else
            return new ResultModel { status = false, message = "错误的登录名和密码!" };
        }

        public class LoginViewModel
        {
            public string name { get; set; }
            public string pass { get; set; }
        }

        /// <summary>
        /// 获取当前的登录信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public object GetCurrentLogin()
        {
            //读取menu数据
            var menuString = File.ReadAllText(ServerUtil.MapPath("menu.json"));
            var menuObjects = JsonConvert.DeserializeObject(menuString);

            return new {
                Name = "管理员",
                Roles = "管理员",
                Menus = menuObjects
            };
        }

        [HttpGet]
        [Authorize(Users = "admin")]
        public string Check()
        {
            return "登录成功! 当前登录ID为" + User.Identity.GetUserId();
        }

        [HttpGet]
        [AllowAnonymous]
        public string Logout()
        {
            AuthenticationManager.SignOut();
            return "登出成功";
        }
    }
}
