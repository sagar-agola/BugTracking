using BugTracking.Business.Contracts.Repositories.General;
using BugTracking.Database.Domain;
using System.Collections.Generic;

namespace BugTracking.Business.Contracts.Repositories.Role
{
    public interface IRoleRepository : IBaseRepository<User_Roles>
    {
        List<User_Roles> GetAllRoles();
    }
}
