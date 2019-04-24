using BugTracking.Business.Contracts.Services.Bugs;
using System.Collections.Generic;
using BugTracking.Business.ViewModels;
using BugTracking.Business.Dal;
using BugTracking.Database.Domain;
using AutoMapper;
using System;
using BugTracking.Business.Models;
using System.Linq;

namespace BugTracking.Business.Service.Bugs
{
    public class BugService : IBugService
    {
        private UnitOfWork unitOfWork;

        public void Create(BugViewModel model)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Bug modelMapping = Mapper.Map<BugViewModel, Bug>(model);
                unitOfWork.BugRepository.Insert(modelMapping);
                unitOfWork.BugRepository.Save();
            }
        }

        public void Delete(int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Bug model = unitOfWork.BugRepository.Get(id);
                unitOfWork.BugRepository.Delete(model);
                unitOfWork.BugRepository.Save();
            }
        }

        public BugViewModel Get(int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Bug model = unitOfWork.BugRepository.GetById(id);
                return MapBugModel(model);
            }
        }

        public List<BugViewModel> GetAll()
        {
            using (unitOfWork = new UnitOfWork())
            {
                List<Bug> bugList = unitOfWork.BugRepository.GetAll();
                List<BugViewModel> bugMappingList = new List<BugViewModel>();

                for(int i = 0; i < bugList.Count; i++)
                {
                    bugMappingList.Add(MapBugModel(bugList[i]));
                }

                return bugMappingList;
            }
        }

        public List<BugViewModel> GetByUserId(int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                List<Bug> bugList = unitOfWork.BugRepository.GetByUserId(id);
                List<BugViewModel> bugMappingList = new List<BugViewModel>();

                for (int i = 0; i < bugList.Count; i++)
                {
                    bugMappingList.Add(MapBugModel(bugList[i]));
                }

                return bugMappingList;
            }
        }

        public CreateBug GetDataForCreateBug()
        {
            using (unitOfWork = new UnitOfWork())
            {
                List<Project> projects = unitOfWork.ProjectRepository.FindBy(p => p.IsActive).ToList();
                List<User> users = unitOfWork.UserRepository.FindBy(u => u.IsActive).ToList();
                List<Bug_priorities> priorities = unitOfWork.BugPriorityRepository.GetAll();
                List<Bug_Status> statusList = unitOfWork.BugStatusRepository.GetAll();

                return new CreateBug
                {
                    Projects = Mapper.Map<List<Project>, List<ProjectViewModel>>(projects),
                    Users = Mapper.Map<List<User>, List<UserViewModel>>(users),
                    Priorities = Mapper.Map<List<Bug_priorities>, List<Bug_PrioritiesViewModel>>(priorities),
                    StatusList = Mapper.Map<List<Bug_Status>, List<Bug_StatusViewModel>>(statusList),
                };
            }
        }

        public List<BugViewModel> GetForTester()
        {
            using (unitOfWork = new UnitOfWork())
            {
                List<Bug> bugList = unitOfWork.BugRepository.GetForTester();
                List<BugViewModel> bugMappingList = new List<BugViewModel>();

                for (int i = 0; i < bugList.Count; i++)
                {
                    bugMappingList.Add(MapBugModel(bugList[i]));
                }

                return bugMappingList;
            }
        }

        public int OpenBugCount()
        {
            using (unitOfWork = new UnitOfWork())
            {
                return unitOfWork.BugRepository.OpenBugCount();
            }
        }

        public void Update(BugViewModel model)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Bug modelMapping = Mapper.Map<BugViewModel, Bug>(model);
                unitOfWork.BugRepository.Update(modelMapping);
                unitOfWork.BugRepository.Save();
            }
        }

        private BugViewModel MapBugModel(Bug model)
        {
            BugViewModel modelMapping = Mapper.Map<Bug, BugViewModel>(model);

            modelMapping.Bug_PrioritiesViewModel = Mapper.Map<Bug_priorities, Bug_PrioritiesViewModel>(model.Bug_priorities);
            modelMapping.Bug_StatusViewModel = Mapper.Map<Bug_Status, Bug_StatusViewModel>(model.Bug_Status);
            modelMapping.ProjectViewModel = MapProject(model.Project);
            modelMapping.UserViewModel = Mapper.Map<User, UserViewModel>(model.User);

            return modelMapping;
        }

        private ProjectViewModel MapProject(Project model)
        {
            ProjectViewModel modelMapping = Mapper.Map<Project, ProjectViewModel>(model);

            modelMapping.Project_TechnologiesViewModel = Mapper.Map<Project_Technologies, Project_TechnologiesViewModel>(model.Project_Technologies);
            modelMapping.Project_StatusViewModel = Mapper.Map<Project_Status, Project_StatusViewModel>(model.Project_Status);

            return modelMapping;
        }
    }
}
