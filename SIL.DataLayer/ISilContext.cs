using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.Domain;

namespace SIL.DataLayer
{
    public interface ISilContext : IContext
    {
         IDbSet<Website> Websites { get; }
         IDbSet<Server> Servers { get;  }
         IDbSet<IP> Ips { get; }
         IDbSet<Release> Releases { get;  }

         IDbSet<Contact> Contacts { get; }
         IDbSet<AuditLog> AuditLog { get; }
         IDbSet<User> Users { get; }
         IDbSet<Customer> Companies { get;  }
    }
}
