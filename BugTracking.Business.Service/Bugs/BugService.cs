using BugTracking.Business.Contracts.Services.Bugs;
using System.Collections.Generic;
using BugTracking.Business.ViewModels;
using BugTracking.Business.Dal;
using BugTracking.Database.Domain;
using AutoMapper;

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

        public int OpenBugCount()
        {
            using (unitOfWork = new UnitOfWork())
            {
                return unitOfWork.ProjectRepository.ActiveProjectCount();
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
            modelMapping.ProjectViewModel = Mapper.Map<Project, ProjectViewModel>(model.Project);
            modelMapping.UserViewModel = Mapper.Map<User, UserViewModel>(model.User);

            return modelMapping;
        }
    }
}
