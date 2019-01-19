using BugTracking.Business.Contracts.Repositories.General;
using BugTracking.Database.Domain;
using System.Collections.Generic;

namespace BugTracking.Business.Contracts.Repositories.ProjectStatus
{
    public interface IProjectStatusReporitory : IBaseRepository<Project_Status>
    {
        new List<Project_Status> GetAll();

        Project_Status GetById(int id);
    }
}
