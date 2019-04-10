using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BugTracking.Business.Contracts.Services.BugStatus;
using BugTracking.Business.Dal;
using BugTracking.Business.ViewModels;
using BugTracking.Database.Domain;

namespace BugTracking.Business.Service.BugStatus
{
    public class BugStatusService : IBugStatusService
    {
        private UnitOfWork unitOfWork;

        public void Create(Bug_StatusViewModel model)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Bug_Status modelMapping = Mapper.Map<Bug_StatusViewModel, Bug_Status>(model);
                unitOfWork.BugStatusRepository.Insert(modelMapping);
                unitOfWork.BugStatusRepository.Save();
            }
        }

        public void Delete(int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Bug_Status entity = unitOfWork.BugStatusRepository.Get(id);
                unitOfWork.BugStatusRepository.Delete(entity);
                unitOfWork.BugStatusRepository.Save();
            }
        }

        public Bug_StatusViewModel Get(int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Bug_Status model = unitOfWork.BugStatusRepository.GetById(id);

                return MapBugStatus(model);
            }
        }

        public List<Bug_StatusViewModel> GetAll()
        {
            using (unitOfWork = new UnitOfWork())
            {
                List<Bug_Status> bugList = unitOfWork.BugStatusRepository.GetAll();
                List<Bug_StatusViewModel> bugListMapping = new List<Bug_StatusViewModel>();

                for(int i = 0; i < bugList.Count; i++)
                {
                    Bug_StatusViewModel model = Mapper.Map<Bug_Status, Bug_StatusViewModel>(bugList[i]);
                    model.BugViewModels = Mapper.Map<ICollection<Bug>, ICollection<BugViewModel>>(bugList[i].Bugs);
                    bugListMapping.Add(model);
                }
                return bugListMapping;
            }
        }

        public void Update(Bug_StatusViewModel model)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Bug_Status modelMapping = Mapper.Map<Bug_StatusViewModel, Bug_Status>(model);
                unitOfWork.BugStatusRepository.Update(modelMapping);
                unitOfWork.BugStatusRepository.Save();
            }
        }

        private Bug_StatusViewModel MapBugStatus(Bug_Status model)
        {
            Bug_StatusViewModel modelMapping = Mapper.Map<Bug_Status, Bug_StatusViewModel>(model);
            modelMapping.BugViewModels = Mapper.Map<ICollection<Bug>, ICollection<BugViewModel>>(model.Bugs);

            List<Bug> listModel = model.Bugs.ToList();
            List<BugViewModel> listModelMapping = new List<BugViewModel>();

            for(int i = 0; i < listModel.Count; i++)
            {
                listModelMapping.Add(MapBug(listModel[i]));
            }

            modelMapping.BugViewModels = listModelMapping;

            return modelMapping;
        }

        private BugViewModel MapBug(Bug model)
        {
            BugViewModel modelMapping = Mapper.Map<Bug, BugViewModel>(model);

            modelMapping.ProjectViewModel = Mapper.Map<Project, ProjectViewModel>(model.Project);

            return modelMapping;
        }
    }
}
