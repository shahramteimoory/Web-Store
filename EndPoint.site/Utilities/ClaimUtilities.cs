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

        public static List<string> GetUserRoles(ClaimsPrincipal User)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            List<string> GetUserRoles = new List<string>();
            foreach (var claim in claimsIdentity.Claims.Where(p => p.Type.EndsWith("role")))
            {
                GetUserRoles.Add(claim.Value);
            }
            return GetUserRoles;


        }
    }
}

