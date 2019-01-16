using BugTracking.Business.Contracts.Repositories.BugStatus;
using BugTracking.Business.Dal.Repositories.General;
using BugTracking.Database.Domain;

namespace BugTracking.Business.Dal.Repositories.BugStatus
{
    public class BugStatusRepository : BaseRepository<Bug_Status>, IBugStatusRepository
    {
        public BugStatusRepository(BugTrackingEntities context) : base(context)
        {
            Context = context;
        }
    }
}
