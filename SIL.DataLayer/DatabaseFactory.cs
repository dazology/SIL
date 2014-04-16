using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIL.DataLayer
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private SILContext dataContext;
        public SILContext Get()
        {
            return dataContext ?? (dataContext = new SILContext());
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }


    }
}
