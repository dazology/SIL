using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace SIL.Web.Core.Models
{
    public class SILUser : IIdentity
    {
        public string DisplayName { get; private set; }
        public string RoleName { get; private set; }
        public int UserId { get; private set; }

        public SILUser()
        {

        }

        public SILUser(string name, string displayName, int userId)
        {
            this.Name = name;
            this.DisplayName = displayName;
            this.UserId = userId;
        }
        public SILUser(string name, string displayName, int userId,string roleName)
        {
            this.Name = name;
            this.DisplayName = displayName;
            this.UserId = userId;
            this.RoleName = roleName;
        }
        public SILUser(string name, UserInfo userInfo)
            : this(name, userInfo.DisplayName, userInfo.UserId,userInfo.RoleName)
        {
            if (userInfo == null) throw new ArgumentNullException("userInfo");
            this.UserId = userInfo.UserId;
        }

        public SILUser(FormsAuthenticationTicket ticket)
            : this(ticket.Name, UserInfo.FromString(ticket.UserData))
        {
            if (ticket == null) throw new ArgumentNullException("ticket");
        }

        public string Name { get; private set; }

        public string AuthenticationType
        {
            get { return "EFMVCForms"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }


    }
}
