using BugTracking.Business.ViewModels;
using System.Collections.Generic;

namespace BugTracking.Business.Contracts.Services.ProjectDevelopers
{
    public interface IProjectDevelopersService
    {
        List<Project_DevelopersViewModel> GetbyProjectId(int id);

        void Create(Project_DevelopersViewModel model);
    }
}
