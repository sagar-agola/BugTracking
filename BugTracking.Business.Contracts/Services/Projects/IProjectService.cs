using BugTracking.Business.ViewModels;
using System.Collections.Generic;

namespace BugTracking.Business.Contracts.Services.Projects
{
    public interface IProjectService
    {
        void Create(ProjectViewModel model);

        ProjectViewModel Get(int id);

        List<ProjectViewModel> GetAll();

        void Update(ProjectViewModel model);

        void Delete(int id);

        int ActiveProjectCount();

        int ProductCount();
    }
}
