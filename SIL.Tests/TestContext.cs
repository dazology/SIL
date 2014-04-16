using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIL.DataLayer;
using SIL.DataLayer.Repository;
using SIL.Domain;

namespace SIL.Tests
{
   public  class TestContext
    {
     
       public TestContext()
       {
   

       }
       [TestMethod]
       public void CanInsertWebsite()
       {
           //var guidWebsite = Guid.NewGuid().ToString();

           //using (var context = new SILContext())
           //{

           //    using (var uow = new DataLayer.UnitOfWork<SILContext>(context))
           //    {
           //        using (var repo = new WebsiteRepository(uow))
           //        {
           //            repo.InsertOrUpdate(new Website
           //            {
           //                Id = 1,
           //                SiteName = "inchcape_vw_boloton",
           //                IPAddress = "http://www.volkswagenbolton.co.uk",
           //                DatabaseName = "inchcape_vw_boloton_v123",
           //                Companies = new Company { WebSiteId = 1, Name = "Inchcape" },
           //                IsActive = true

           //            });

           //            uow.Save();
           //        }
           //    }

           //}
       }     


    }
}
