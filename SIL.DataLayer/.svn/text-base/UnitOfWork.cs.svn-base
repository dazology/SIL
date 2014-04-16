using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIL.DataLayer
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : IContext, new()
    {
        private readonly IDatabaseFactory databaseFactory;
        private SILContext dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        public void Commit()
        {
             DataContext.Commit();
        }

        public SILContext DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }

        public void Dispose()
        {
            DataContext.Dispose();
        }
    }
}
