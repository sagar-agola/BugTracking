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

        public void DeleteByProjectId(int id)
        {
            List<Bug> bugs = Context.Bugs
                .Where(bug => bug.ProjectId == id)
                .ToList();

            for(int i = 0; i < bugs.Count; i++)
            {
                Delete(bugs[i]);
            }
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
                .Include(bug => bug.Bug_Status)
                .Where(bug => bug.UserId == id && (bug.Bug_Status.BugStatus == "new" || bug.Bug_Status.BugStatus == "Open"))
                .Include(bug => bug.Project)
                .Include(bug => bug.Bug_priorities)
                .ToList();
        }

        public List<Bug> GetForTester()
        {
            return Context.Bugs
                .Include(bug => bug.Bug_Status)
                .Where(bug => bug.Bug_Status.BugStatus != "Solved")
                .Include(bug => bug.Bug_priorities)
                .Include(bug => bug.Project)
                .ToList();
        }

        public int OpenBugCount()
        {
            return Context.Bugs
                .Where(bug => bug.Bug_Status.BugStatus != "Solved")
                .Count();
        }

        List<Bug> IBugRepository.GetAll()
        {
            return Context.Bugs
                .Include(bug => bug.Bug_Status)
                .Where(bug => bug.Bug_Status.BugStatus != "Solved")
                .Include(bug => bug.User)
                .Include(bug => bug.Project)
                .Include(bug => bug.Bug_priorities)
                .ToList();
        }
    }
}
