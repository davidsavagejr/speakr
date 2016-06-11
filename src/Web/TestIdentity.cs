using System.Collections.Generic;
using System.Security.Claims;

namespace Web
{
    public class TestPrincipal : ClaimsPrincipal
    {
        public TestPrincipal() : base(new TestIdentity()) { }
    }

    public class TestIdentity : ClaimsIdentity
    {
        public override bool IsAuthenticated => true;

        public TestIdentity() : base(TestClaims) { }

        public static IEnumerable<Claim> TestClaims => new List<Claim>()
        {
            new Claim(ClaimTypes.Name, "johndoe@mailinator.com"),
            new Claim(ClaimTypes.NameIdentifier, "9999999999999"),
            new Claim(ClaimTypes.Email, "johndoe@mailinator.com"),
            new Claim(ClaimTypes.GivenName, "John"),
            new Claim(ClaimTypes.Surname, "Doe"),
            new Claim(ClaimTypes.Name, "John Doe")
        };
    }
}