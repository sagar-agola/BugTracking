using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracking.Database.Domain;

namespace BugTracking.Business.Dal
{
    public class UnitOfWork : IDisposable
    {
        private readonly BugTrackingEntities context = new BugTrackingEntities();

        public UnitOfWork()
        {

        }

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
