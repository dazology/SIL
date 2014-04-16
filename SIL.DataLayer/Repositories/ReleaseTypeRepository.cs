using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.DataLayer.Repository;
using SIL.Domain;

namespace SIL.DataLayer.Repositories
{
    class ReleaseTypeRepository : BaseRepository<ReleaseType>, IReleaseTypeRepository
    {
        public ReleaseTypeRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
