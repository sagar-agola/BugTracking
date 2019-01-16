using AutoMapper;
using BugTracking.Business.Contracts.Services.BugStatus;
using BugTracking.Business.Dal;
using BugTracking.Business.ViewModels;
using BugTracking.Database.Domain;

namespace BugTracking.Business.Service.BugStatus
{
    public class BugStatusService : IBugStatusService
    {
        public void Create(Bug_StatusViewModel model)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                Bug_Status modelMapping = Mapper.Map<Bug_StatusViewModel, Bug_Status>(model);
                unitOfWork.BugStatusRepository.Insert(modelMapping);
                unitOfWork.BugStatusRepository.Save();
            }
        }
    }
}
