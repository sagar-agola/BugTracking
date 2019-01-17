using BugTracking.Business.Contracts.Repositories.General;
using BugTracking.Database.Domain;

namespace BugTracking.Business.Contracts.Repositories.BugPriority
{
    public interface IBugPriorityRepository : IBaseRepository<Bug_priorities>
    {
    }
}
