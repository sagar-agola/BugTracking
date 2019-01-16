using BugTracking.Business.Contracts.Repositories.General;
using BugTracking.Database.Domain;

namespace BugTracking.Business.Contracts.Repositories.BugStatus
{
    public interface IBugStatusRepository : IBaseRepository<Bug_Status>
    {
    }
}
