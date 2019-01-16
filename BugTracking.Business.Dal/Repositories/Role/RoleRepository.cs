using System.Collections.Generic;
using BugTracking.Business.Contracts.Repositories.Role;
using BugTracking.Business.Dal.Repositories.General;
using BugTracking.Database.Domain;
using System.Data.Entity;
using System.Linq;

namespace BugTracking.Business.Dal.Repositories.Role
{
    public class RoleRepository : BaseRepository<User_Roles>, IRoleRepository
    {
        public RoleRepository(BugTrackingEntities context) : base(context)
        {
            Context = context;
        }

        public List<User_Roles> GetAllRoles()
        {
            return Context.User_Roles.Include(r => r.Users).ToList();
        }
    }
}
