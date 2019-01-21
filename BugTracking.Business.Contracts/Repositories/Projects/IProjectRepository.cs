using BugTracking.Business.Contracts.Repositories.General;
using BugTracking.Database.Domain;
using System.Collections.Generic;

namespace BugTracking.Business.Contracts.Repositories.Projects
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        new List<Project> GetAll();

        Project GetById(int id);

        int ActiveProjectCount();
    }
}
