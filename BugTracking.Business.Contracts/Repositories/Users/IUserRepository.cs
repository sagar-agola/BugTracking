using BugTracking.Business.Contracts.Repositories.General;
using BugTracking.Database.Domain;

namespace BugTracking.Business.Contracts.Repositories.Users
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
