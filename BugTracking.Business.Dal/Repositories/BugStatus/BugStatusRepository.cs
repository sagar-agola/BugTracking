﻿using System.Collections.Generic;
using BugTracking.Business.Contracts.Repositories.BugStatus;
using BugTracking.Business.Dal.Repositories.General;
using BugTracking.Database.Domain;
using System.Data.Entity;
using System.Linq;

namespace BugTracking.Business.Dal.Repositories.BugStatus
{
    public class BugStatusRepository : BaseRepository<Bug_Status>, IBugStatusRepository
    {
        public BugStatusRepository(BugTrackingEntities context) : base(context)
        {
            Context = context;
        }

        List<Bug_Status> IBugStatusRepository.GetAll()
        {
            return Context.Bug_Status.Include(bug => bug.Bugs).ToList();
        }
    }
}
