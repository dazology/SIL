using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SIL.Domain;
using System.Data.Entity;

namespace SIL.DataLayer.Repository
{
    public class WebsiteRepository : BaseRepository<Website>, IWebsiteRepository 
    {
        public WebsiteRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}
