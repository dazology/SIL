using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using SIL.Web.Core.Models;

namespace SIL.Web.Core.Extensions
{
    public static class SecurityExtension
    {
        public static string Name(this IPrincipal user)
        {
            return user.Identity.Name;
        }

        public static bool InAnyRole(this IPrincipal user, params string[] roles)
        {
            foreach (string role in roles)
            {
                if (user.IsInRole(role)) return true;
            }
            return false;
        }
        public static SILUser GetSilUser(this IPrincipal principal)
        {
            if (principal.Identity is SILUser)
                return (SILUser)principal.Identity;
            else
                return new SILUser(string.Empty, new UserInfo());
        }
    }
}
