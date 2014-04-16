using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.Domain;

namespace SIL.DataLayer.Migrations
{
    public class DbInitialize : DropCreateDatabaseIfModelChanges<SIL.DataLayer.SILContext>
    {

        protected override void Seed(SIL.DataLayer.SILContext context)
    {
        //var IPItems = new[]
        //     {
        //        new IP
        //        {
        //           IPAddress = "62.173.101.37",

        //        },
                
        //       new IP
        //       {
        //           IPAddress = "89.206.184.193",

        //       }
        //     };


        //var ContactItems = new[]
        //     {
        //        new Contact
        //        {
        //            Name="Angela Jemison", 
        //            EmailAddress = "Angela.Jemison@inchcape.co.uk",
        //            IsPrimary = true
        //        },
        //     };

        //var ServerItem = new[]
        //     {
        //        new Server
        //        {
        //            HostName = "WB01",
        //            FriendlyName = "WB01",
        //            Description = "Star Managed Server",
        //        },
                
        //        new Server
        //        {
        //            HostName = "WB02",
        //            FriendlyName = "WB02",
        //            Description = "Star Managed Server",
        //        },
                
        //        new Server
        //        {
        //            HostName = "WB03",
        //            FriendlyName = "WB03",
        //            Description = "Star Managed Server",
        //        },
        //     };

        //var WebItem = new[]
        //        {
        //            new Website
        //            {

        //                SiteName = "Inchcape Volkswagen", URL  = "http://www.inchcape-volkswagen.co.uk ",    IsActive = true, PSUOwned = true, Pingdom = true
        //            },
        //        };

        //context.Servers.Add(new Server()
        //{
        //    HostName = "WB01",
        //    FriendlyName = "WB01",
        //    Description = "Star Managed Server",
        //    //Ips = new List<IP>
        //    //    {
        //    //            IPItems[0],
        //    //    }
        //});

        //context.Companies.Add(new Customer()
        //{
        //   // WebSiteId = WebItem[0].WebsiteId,
        //    Name = "Inchcape",
        //    //Contacts = new List<Contact>
        //    //    {
        //    //        ContactItems[0],        
        //    //    }
        //});

        //context.Websites.Add(new Website()
        //{
        //    SiteName = "Inchcape Volkswagen",
        //    URL = "http://www.inchcape-volkswagen.co.uk ",
        //    IsActive = true,
        //    PSUOwned = true,
        //    Pingdom = true,
        //    DatabaseName = "Inchcape_vw_v1234",


        //    //Companies  = new List<Company>
        //    //{

        //    //}
        //});

    }

    }


}
