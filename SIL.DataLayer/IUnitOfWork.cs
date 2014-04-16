using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIL.DataLayer
{
    public interface IUnitOfWork: IDisposable 
    {
        void Commit();
    }
}
