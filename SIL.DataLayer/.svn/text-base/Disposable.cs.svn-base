using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIL.DataLayer
{
  public  class Disposable : IDisposable
    {
      private bool isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        protected virtual void DisposeCore()
        {
        }
    }
}
