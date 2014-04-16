using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIL.Web.Core.Models
{
    public class Roles
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
    public enum UserRoles
    {
        Admin = 1,
        User = 2
    }
}
