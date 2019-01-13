using BugTracking.Business.ViewModels;

namespace BugTracking.Business.Contracts.Services.Status
{
    public interface IStatusService
    {
        void Create(Bug_StatusViewModel model);
    }
}
