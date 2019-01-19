using System;
using BugTracking.Database.Domain;
using BugTracking.Business.Contracts.Repositories.BugStatus;
using BugTracking.Business.Dal.Repositories.BugStatus;
using BugTracking.Business.Contracts.Repositories.Role;
using BugTracking.Business.Dal.Repositories.Role;
using BugTracking.Business.Contracts.Repositories.Users;
using BugTracking.Business.Dal.Repositories.Users;
using BugTracking.Business.Contracts.Repositories.BugPriority;
using BugTracking.Business.Dal.Repositories.BugPriority;
using BugTracking.Business.Contracts.Repositories.Bugs;
using BugTracking.Business.Dal.Repositories.Bugs;
using BugTracking.Business.Contracts.Repositories.ProjectTechnology;
using BugTracking.Business.Dal.Repositories.ProjectTechnology;
using BugTracking.Business.Contracts.Repositories.ProjectStatus;
using BugTracking.Business.Dal.Repositories.ProjectStatus;

namespace BugTracking.Business.Dal
{
    public class UnitOfWork : IDisposable
    {
        private readonly BugTrackingEntities context;

        #region Constructor
        public UnitOfWork()
        {
            context = new BugTrackingEntities();

            RoleRepository = new RoleRepository(context);
            UserRepository = new UserRepository(context);
            BugStatusRepository = new BugStatusRepository(context);
            BugPriorityRepository = new BugPriorityRepository(context);
            BugRepository = new BugRepository(context);
            ProjectTechnologyRepository = new ProjectTechnologyRepository(context);
            ProjectStatusReporitory = new ProjectStatusRepository(context);
        }
        #endregion

        #region Properties
        public IRoleRepository RoleRepository { get; }
        public IUserRepository UserRepository { get; }
        public IBugStatusRepository BugStatusRepository { get; }
        public IBugPriorityRepository BugPriorityRepository { get; }
        public IBugRepository BugRepository { get; }
        public IProjectTechnologyRepository ProjectTechnologyRepository { get; }
        public IProjectStatusReporitory ProjectStatusReporitory { get; }
        #endregion

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
