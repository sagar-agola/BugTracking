using BugTracking.Business.Contracts.Repositories.ProjectStatus;
using BugTracking.Business.Dal.Repositories.General;
using BugTracking.Database.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Z.EntityFramework.Plus;

namespace BugTracking.Business.Dal.Repositories.ProjectStatus
{
    public class ProjectStatusRepository : BaseRepository<Project_Status>, IProjectStatusReporitory
    {
        public ProjectStatusRepository(BugTrackingEntities context) : base(context)
        {
            Context = context;
        }

        public Project_Status GetById(int id)
        {
            return Context.Project_Status
                .Where(status => status.Id == id)
                .Include(status => status.Projects)
                .FirstOrDefault();
        }

        List<Project_Status> IProjectStatusReporitory.GetAll()
        {
            return Context.Project_Status
                .IncludeFilter(status => status.Projects
                    .Where(project => project.IsActive))
                .ToList();
        }
    }
}
