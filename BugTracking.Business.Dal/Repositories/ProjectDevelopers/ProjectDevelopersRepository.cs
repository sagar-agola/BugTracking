using BugTracking.Business.Contracts.Repositories.ProjectDevelopers;
using BugTracking.Business.Dal.Repositories.General;
using BugTracking.Database.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BugTracking.Business.Dal.Repositories.ProjectDevelopers
{
    public class ProjectDevelopersRepository : BaseRepository<Project_Developers>, IProjectDevelopersRepository
    {
        public ProjectDevelopersRepository(BugTrackingEntities context) : base(context)
        {
            Context = context;
        }

        public List<Project_Developers> GetByProjectId(int id)
        {
            return Context.Project_Developers
                .Where(project => project.ProjectId == id)
                .Include(project => project.Project)
                .Include(project => project.User)
                .ToList();
        }

        public Project_Developers GetByUserId(int id)
        {
            return Context.Project_Developers
                .Where(project => project.UserId == id
                    && project.Project.Project_Status.ProjectStatus != "Finished"
                    && project.Project.Project_Status.ProjectStatus != "Completed")
                .Include(project => project.User)
                .Include(project => project.Project)
                .FirstOrDefault();
        }

        public void RemoveDeveloper(int projId, int devId)
        {
            Project_Developers model = Context.Project_Developers
                .Where(proj => proj.ProjectId == projId && proj.UserId == devId)
                .FirstOrDefault();
            Context.Project_Developers.Remove(model);
        }
    }
}
