using System.Collections.Generic;
using BugTracking.Business.Contracts.Repositories.BugPriority;
using BugTracking.Business.Dal.Repositories.General;
using BugTracking.Database.Domain;
using System.Data.Entity;
using System.Linq;

namespace BugTracking.Business.Dal.Repositories.BugPriority
{
    public class BugPriorityRepository : BaseRepository<Bug_priorities>, IBugPriorityRepository
    {
        public BugPriorityRepository(BugTrackingEntities context) : base(context)
        {
            Context = context;
        }

        public Bug_priorities GetById(int id)
        {
            return Context.Bug_priorities
                .Where(x => x.Id == id)
                .Include(x => x.Bugs)
                .FirstOrDefault();
        }

        List<Bug_priorities> IBugPriorityRepository.GetAll()
        {
            return Context.Bug_priorities
                .Include(x => x.Bugs)
                .ToList();
        }
    }
}
