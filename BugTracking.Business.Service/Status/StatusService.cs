using AutoMapper;
using BugTracking.Business.Contracts.Services.Status;
using BugTracking.Business.Dal;
using BugTracking.Business.ViewModels;
using BugTracking.Database.Domain;

namespace BugTracking.Business.Service.Status
{
    public class StatusService : IStatusService
    {
        public void Create(Bug_StatusViewModel model)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                Bug_Status modelMapping = Mapper.Map<Bug_StatusViewModel, Bug_Status>(model);
                unitOfWork.StatusRepository.Insert(modelMapping);
                unitOfWork.StatusRepository.Save();
            }
        }
    }
}
