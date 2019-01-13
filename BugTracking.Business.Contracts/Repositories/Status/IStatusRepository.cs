using BugTracking.Business.Contracts.Repositories.General;
using BugTracking.Database.Domain;

namespace BugTracking.Business.Contracts.Repositories.Status
{
    public interface IStatusRepository : IBaseRepository<Bug_Status>
    {
    }
}
