using BugTracking.Business.ViewModels;

namespace BugTracking.Business.Contracts.Services.BugStatus
{
    public interface IBugStatusService
    {
        void Create(Bug_StatusViewModel model);
    }
}
