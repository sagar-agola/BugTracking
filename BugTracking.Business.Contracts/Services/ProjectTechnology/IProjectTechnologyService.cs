using BugTracking.Business.ViewModels;
using System.Collections.Generic;

namespace BugTracking.Business.Contracts.Services.ProjectTechnology
{
    public interface IProjectTechnologyService
    {
        void Create(Project_TechnologiesViewModel model);

        Project_TechnologiesViewModel Get(int id);

        List<Project_TechnologiesViewModel> GetAll();

        void Delete(int id);
    }
}
