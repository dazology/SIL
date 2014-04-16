using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.Domain;
using System.Data.Entity;
using System.Linq.Expressions;
using SIL.DataLayer.Repository;

namespace SIL.DataLayer.Repositories
{
    public class CompanyRepository : BaseRepository<Customer>, ICompanyRepository
    {
        public CompanyRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
