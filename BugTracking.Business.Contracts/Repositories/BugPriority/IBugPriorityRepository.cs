using BugTracking.Business.Contracts.Repositories.General;
using BugTracking.Database.Domain;
using System.Collections.Generic;

namespace BugTracking.Business.Contracts.Repositories.BugPriority
{
    public interface IBugPriorityRepository : IBaseRepository<Bug_priorities>
    {
        new List<Bug_priorities> GetAll();
        Bug_priorities GetById(int id);
    }
}
