using BugTracking.Business.Contracts.Repositories.ProjectTechnology;
using BugTracking.Business.Dal.Repositories.General;
using BugTracking.Database.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BugTracking.Business.Dal.Repositories.ProjectTechnology
{
    public class ProjectTechnologyRepository : BaseRepository<Project_Technologies>, IProjectTechnologyRepository
    {
        public ProjectTechnologyRepository(BugTrackingEntities context) : base(context)
        {
            Context = context;
        }

        public Project_Technologies GetById(int id)
        {
            return Context.Project_Technologies
                .Where(tech => tech.Id == id)
                .Include(tech => tech.Projects)
                .FirstOrDefault();
        }

        List<Project_Technologies> IProjectTechnologyRepository.GetAll()
        {
            return Context.Project_Technologies
                .Include(tech => tech.Projects)
                .ToList();
        }
    }
}
