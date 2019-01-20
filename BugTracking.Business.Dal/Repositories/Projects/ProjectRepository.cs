﻿using BugTracking.Business.Contracts.Repositories.Projects;
using BugTracking.Business.Dal.Repositories.General;
using BugTracking.Database.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking.Business.Dal.Repositories.Projects
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(BugTrackingEntities context) : base(context)
        {
            Context = context;
        }

        public Project GetById(int id)
        {
            return Context.Projects
                .Where(project => project.Id == id)
                .Include(project => project.Project_Developers)
                .Include(project => project.Project_Status)
                .Include(project => project.Project_Technologies)
                .Include(project => project.Bugs)
                .FirstOrDefault();
        }

        List<Project> IProjectRepository.GetAll()
        {
            return Context.Projects
                .Include(project => project.Project_Developers)
                .Include(project => project.Project_Status)
                .Include(project => project.Project_Technologies)
                .Include(project => project.Bugs)
                .ToList();
        }
    }
}
