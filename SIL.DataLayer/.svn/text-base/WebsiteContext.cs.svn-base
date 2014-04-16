using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.Domain;
namespace SIL.DataLayer
{
    public class WebsiteContext : BaseContext<WebsiteContext>
    {
        public DbSet<Website> Websites { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<Customer> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<AuditLog> AuditLog { get; set; }
        
    }
}
