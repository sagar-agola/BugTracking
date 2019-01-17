using BugTracking.Business.ViewModels;
using System.Collections.Generic;

namespace BugTracking.Business.Contracts.Services.BugPriority
{
    public interface IBugPriorityService
    {
        void Create(Bug_PrioritiesViewModel model);
        void Update(Bug_PrioritiesViewModel model);
        void Delete(int id);
        List<Bug_PrioritiesViewModel> GetAll();
    }
}
