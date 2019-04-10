using BugTracking.Business.Contracts.Repositories.General;
using BugTracking.Database.Domain;
using System.Collections.Generic;

namespace BugTracking.Business.Contracts.Repositories.BugStatus
{
    public interface IBugStatusRepository : IBaseRepository<Bug_Status>
    {
        new List<Bug_Status> GetAll();

        Bug_Status GetById(int id);
    }
}
