using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Web
{
    public class TestPrincipal : ClaimsPrincipal
    {
        public TestPrincipal() : base(new TestIdentity())
        {
        }
    }

    public class TestIdentity : ClaimsIdentity
    {
        public override bool IsAuthenticated => true;

        public TestIdentity() : base(TestClaims) { }

        public static IEnumerable<Claim> TestClaims => new List<Claim>()
        {
            new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "johndoe@mailinator.com"),
            new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", DateTime.Now.Ticks.ToString()),
            new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "johndoe@mailinator.com"),
            new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname", "John"),
            new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname", "Doe")
        };
    }
}