using BugTracking.Business.Contracts.Repositories.BugPriority;
using BugTracking.Business.Dal.Repositories.General;
using BugTracking.Database.Domain;

namespace BugTracking.Business.Dal.Repositories.BugPriority
{
    public class BugPriorityRepository : BaseRepository<Bug_priorities>, IBugPriorityRepository
    {
        public BugPriorityRepository(BugTrackingEntities context) : base(context)
        {
            Context = context;
        }
    }
}
