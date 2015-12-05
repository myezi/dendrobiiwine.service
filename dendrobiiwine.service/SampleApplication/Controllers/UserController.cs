using SampleApplication.Base;
using SampleApplication.Business;
using SampleApplication.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace SampleApplication.Controllers
{
    [Module(AllowModules = Module.Vehicle | Module.Booking)]
    public class UserController : ApiController
    {
        [HttpGet]
        public async Task<UserModel[]> GetUsersAsync()
        {
            var users = await UserManager.GetUsersAsync();
            return users;
        }

        [EnableCors]
        [AllowAnonymous]
        [HttpGet]
        public UserModel[] GetUsers()
        {
            var users = UserManager.GetUsers();
            return users;
        }

        private static UserModel[] _users;
        [HttpGet]
        public UserModel[] GetUsersCache()
        {
            if(_users == null)
                _users = UserManager.GetUsers();
            return _users;
        }

        [HttpPost]
        public bool SaveUser(UserModel user)
        {
            return true;
        }
    }
}
