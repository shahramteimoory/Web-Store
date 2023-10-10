using System;
using System.Security.Claims;

namespace EndPoint.site.Utilities
{
    public static class ClaimUtilities
    {
        public static long? GetUserId(ClaimsPrincipal User)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null && claimsIdentity.FindFirst(ClaimTypes.NameIdentifier) != null)
            {
                long userId = long.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
                return userId;
            }

            return null;
        }

    }
 }

