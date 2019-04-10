using BugTracking.Business.ViewModels;
using System.Collections.Generic;

namespace BugTracking.Business.Contracts.Services.BugStatus
{
    public interface IBugStatusService
    {
        void Create(Bug_StatusViewModel model);

        void Update(Bug_StatusViewModel model);

        void Delete(int id);

        List<Bug_StatusViewModel> GetAll();

        Bug_StatusViewModel Get(int id);
    }
}
