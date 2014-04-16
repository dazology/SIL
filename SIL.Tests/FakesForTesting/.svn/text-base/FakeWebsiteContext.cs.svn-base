using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.DataLayer;

namespace SIL.Tests
{
    public class FakeWebsiteContext : ISilContext 
    {
        public FakeWebsiteContext()
        {
            Websites = new WebsiteFakeDbSet();
        }

        public System.Data.Entity.IDbSet<Domain.Website> Websites { get; private set; }        
        public System.Data.Entity.IDbSet<Domain.Server> Servers  { get; private set; }
        public System.Data.Entity.IDbSet<Domain.IP> Ips  { get; private set; }
        public System.Data.Entity.IDbSet<Domain.Release> Releases  { get; private set; }
        public System.Data.Entity.IDbSet<Domain.Contact> Contacts  { get; private set; }   
        public System.Data.Entity.IDbSet<AuditLog> AuditLog  { get; private set; }
        public System.Data.Entity.IDbSet<Domain.User> Users  { get; private set; }
        public System.Data.Entity.IDbSet<Domain.Customer> Companies  { get; private set; }


        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void SetModified(object entity)
        {
            throw new NotImplementedException();
        }

        public void SetAdd(object entity)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
          
        }
    }
}
