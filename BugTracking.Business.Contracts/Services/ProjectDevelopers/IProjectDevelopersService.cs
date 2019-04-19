using BugTracking.Business.ViewModels;
using System.Collections.Generic;

namespace BugTracking.Business.Contracts.Services.ProjectDevelopers
{
    public interface IProjectDevelopersService
    {
        List<Project_DevelopersViewModel> GetbyProjectId(int id);

        Project_DevelopersViewModel GetbyUserId(int id);

        void Create(Project_DevelopersViewModel model);

        void RemoveDeveloper(int projId, int devId);
    }
}
