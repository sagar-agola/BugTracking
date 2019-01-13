using BugTracking.Business.Contracts.Repositories.Status;
using BugTracking.Business.Dal.Repositories.General;
using BugTracking.Database.Domain;

namespace BugTracking.Business.Dal.Repositories.Status
{
    public class StatusRepository : BaseRepository<Bug_Status>, IStatusRepository
    {
        public StatusRepository(BugTrackingEntities context) : base(context)
        {
            Context = context;
        }
    }
}
