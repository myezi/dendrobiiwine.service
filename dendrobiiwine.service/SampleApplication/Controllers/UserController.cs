using SampleApplication.Base;
using SampleApplication.Business;
using SampleApplication.Models;
using System.Threading.Tasks;
using System.Web.Http;
using SampleApplication.Data;

namespace SampleApplication.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<UserModel[]> GetUsers()
        {
            return await UserBusiness.GetInstance().GetUsersAsync();
        }

        [HttpPost]
        public bool Save(UserModel user)
        {
            var aUser = new UserData
            {
                UserID = user.Id,
                Name = user.Name,
                Login = user.Login,
                Password = user.Password,
                Email = user.Email,
                QQ = user.QQ,
                Mobile = user.Mobile,
                Role = user.Role,
                Status = user.Role
            };

            return aUser.UserID == 0
                ? UserBusiness.GetInstance().Create(aUser)
                : UserBusiness.GetInstance().Edit(aUser);
        }
    }
}
