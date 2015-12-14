using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Security.Claims;

namespace SampleApplication.Base
{
    public class IdentityUser
    {
      
        public string Id { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string PasswordHash { get; set; }
        private IList<string> _roles;
        public IList<string> Roles {
            get { if (_roles == null) _roles = new List<string>(); return _roles; }
            set { _roles = value; } 
        }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        

        public ClaimsIdentity GenerateUserIdentity()
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, Id));
            claims.Add(new Claim(ClaimTypes.Name, UserName));
            claims.Add(new Claim(ClaimTypes.Role, Roles == null ? "guest" : string.Join(",", Roles)));
            claims.Add(new Claim(ClaimTypes.Email, Email));
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            return new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
        }

      
    }
}
