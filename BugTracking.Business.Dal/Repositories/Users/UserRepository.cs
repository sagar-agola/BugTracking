using BugTracking.Business.Contracts.Repositories.Users;
using BugTracking.Business.Dal.Repositories.General;
using BugTracking.Database.Domain;

namespace BugTracking.Business.Dal.Repositories.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BugTrackingEntities context) : base(context)
        {
            Context = context;
        }
    }
}
