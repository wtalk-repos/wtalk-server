using System;
using System.Security.Claims;
using System.Security.Principal;


namespace Wtalk.Core.Helpers
{
    public static class UserHelper
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            var claimsIdentity = (ClaimsIdentity)principal.Identity;
            var claim = claimsIdentity.FindFirst("UserId");
            return int.Parse(claim.Value);
        }
    }
}
