using BugTracking.Business.Contracts.Services.BugPriority;
using System.Collections.Generic;
using System.Linq;
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

        public List<Bug_PrioritiesViewModel> GetAll()
        {
            using (unitOfWork = new UnitOfWork())
            {
                List<Bug_priorities> bugPriorityList = unitOfWork.BugPriorityRepository.GetAll();
                List<Bug_PrioritiesViewModel> modelMapping = Mapper.Map<List<Bug_priorities>, List<Bug_PrioritiesViewModel>>(bugPriorityList);
                
                for(int i = 0; i < modelMapping.Count; i++)
                {
                    modelMapping[i].BugViewModels = Mapper.Map<ICollection<Bug>, ICollection<BugViewModel>>(bugPriorityList[i].Bugs);
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
    }
}
