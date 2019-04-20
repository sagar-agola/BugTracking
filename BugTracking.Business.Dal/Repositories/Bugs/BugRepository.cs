using BugTracking.Business.Contracts.Repositories.Bugs;
using BugTracking.Business.Dal.Repositories.General;
using BugTracking.Database.Domain;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BugTracking.Business.Dal.Repositories.Bugs
{
    public class BugRepository : BaseRepository<Bug>, IBugRepository
    {
        public BugRepository(BugTrackingEntities context) : base(context)
        {
            Context = context;
        }

        public Bug GetById(int id)
        {
            return Context.Bugs
                .Where(bug => bug.Id == id)
                .Include(bug => bug.User)
                .Include(bug => bug.Project)
                .Include(bug => bug.Bug_priorities)
                .Include(bug => bug.Bug_Status)
                .FirstOrDefault();
        }

        public List<Bug> GetByUserId(int id)
        {
            return Context.Bugs
                .Where(bug => bug.UserId == id)
                .Include(bug => bug.User)
                .Include(bug => bug.Project)
                .Include(bug => bug.Bug_priorities)
                .Include(bug => bug.Bug_Status)
                .ToList();
        }

        public int OpenBugCount()
        {
            return Context.Bugs
                .Where(bug => bug.Bug_Status.BugStatus != "Closed")
                .Count();
        }

        List<Bug> IBugRepository.GetAll()
        {
            return Context.Bugs
                .Include(bug => bug.User)
                .Include(bug => bug.Project)
                .Include(bug => bug.Bug_priorities)
                .Include(bug => bug.Bug_Status)
                .ToList();
        }
    }
}
