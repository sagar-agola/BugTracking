using BugTracking.Business.ViewModels;
using System.Collections.Generic;

namespace BugTracking.Business.Contracts.Services.ProjectStatus
{
    public interface IProjectStatusService
    {
        void Create(Project_StatusViewModel model);

        Project_StatusViewModel Get(int id);

        List<Project_StatusViewModel> GetAll();

        void Delete(int id);
    }
}
