using BugTracking.Business.Contracts.Repositories.General;
using BugTracking.Database.Domain;
using System.Collections.Generic;

namespace BugTracking.Business.Contracts.Repositories.ProjectTechnology
{
    public interface IProjectTechnologyRepository : IBaseRepository<Project_Technologies>
    {
        new List<Project_Technologies> GetAll();

        Project_Technologies GetById(int id);
    }
}
