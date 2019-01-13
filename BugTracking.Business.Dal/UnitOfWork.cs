using System;
using BugTracking.Database.Domain;
using BugTracking.Business.Contracts.Repositories.Status;
using BugTracking.Business.Dal.Repositories.Status;

namespace BugTracking.Business.Dal
{
    public class UnitOfWork : IDisposable
    {
        #region Properties
        private readonly BugTrackingEntities context;
        #endregion

        #region Constructor
        public UnitOfWork()
        {
            context = new BugTrackingEntities();

            StatusRepository = new StatusRepository(context);
        }
        #endregion

        public IStatusRepository StatusRepository { get; }

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
