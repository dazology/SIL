using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIL.DataLayer
{
    public interface IDatabaseFactory : IDisposable
    {
        SILContext Get();
    }
}
