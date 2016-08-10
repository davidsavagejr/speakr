using System.Linq;
using System.Security.Claims;
using Core.Security;

namespace Web.Core.Models
{
    public class WebUser : IUser
    {
        private readonly ClaimsIdentity _user;

        public WebUser(ClaimsIdentity user)
        {
            _user = user;
        }

        public string UserName => _user.Name;
        public string NameIdentifier => GetClaim(ClaimTypes.NameIdentifier);
        public string EmailAddress => GetClaim(ClaimTypes.Email);
        public string Name => GetClaim(ClaimTypes.Name);
        public string GivenName => GetClaim(ClaimTypes.GivenName);
        public string SurName => GetClaim(ClaimTypes.Surname);
        public string KeyForRecords => NameIdentifier;

        private string GetClaim(string typ)
        {
            return _user.Claims.FirstOrDefault(c => c.Type == typ)?.Value;
        }
    }
}