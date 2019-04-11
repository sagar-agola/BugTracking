using BugTracking.Business.Contracts.Services.BugPriority;
using System.Collections.Generic;
using BugTracking.Business.ViewModels;
using BugTracking.Business.Dal;
using BugTracking.Database.Domain;
using AutoMapper;

namespace BugTracking.Business.Service.BugPriority
{
    public class BugPriorityService : IBugPriorityService
    {
        private UnitOfWork unitOfWork;

        public void Create(Bug_PrioritiesViewModel model)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Bug_priorities modelMapping = Mapper.Map<Bug_PrioritiesViewModel, Bug_priorities>(model);
                unitOfWork.BugPriorityRepository.Insert(modelMapping);
                unitOfWork.BugPriorityRepository.Save();
            }
        }

        public void Delete(int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Bug_priorities entity = unitOfWork.BugPriorityRepository.Get(id);
                unitOfWork.BugPriorityRepository.Delete(entity);
                unitOfWork.BugPriorityRepository.Save();
            }
        }

        public Bug_PrioritiesViewModel Get(int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Bug_priorities model = unitOfWork.BugPriorityRepository.GetById(id);

                return MapBugPriprity(model);
            }
        }

        public List<Bug_PrioritiesViewModel> GetAll()
        {
            using (unitOfWork = new UnitOfWork())
            {
                List<Bug_priorities> model = unitOfWork.BugPriorityRepository.GetAll();
                List<Bug_PrioritiesViewModel> modelMapping = new List<Bug_PrioritiesViewModel>();

                for(int i = 0; i < model.Count; i++)
                {
                    modelMapping.Add(MapBugPriprity(model[i]));
                }

                return modelMapping;
            }
        }

        public void Update(Bug_PrioritiesViewModel model)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Bug_priorities modelMapping = Mapper.Map<Bug_PrioritiesViewModel, Bug_priorities>(model);
                unitOfWork.BugPriorityRepository.Update(modelMapping);
                unitOfWork.BugPriorityRepository.Save();
            }
        }

        private Bug_PrioritiesViewModel MapBugPriprity(Bug_priorities model)
        {
            Bug_PrioritiesViewModel modelMapping = Mapper.Map<Bug_priorities, Bug_PrioritiesViewModel>(model);

            modelMapping.BugViewModels = Mapper.Map<ICollection<Bug>, ICollection<BugViewModel>>(model.Bugs);

            return modelMapping;
        }
    }
}
