using BugTracking.Business.Contracts.Repositories.Role;
using BugTracking.Business.Dal.Repositories.General;
using BugTracking.Database.Domain;

namespace BugTracking.Business.Dal.Repositories.Role
{
    class RoleRepository : BaseRepository<User_Roles>, IRoleRepository
    {
        public RoleRepository(BugTrackingEntities context) : base(context)
        {
            Context = context;
        }
    }
}
