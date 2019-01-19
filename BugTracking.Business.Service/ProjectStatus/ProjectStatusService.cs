using BugTracking.Business.Contracts.Services.ProjectStatus;
using System.Collections.Generic;
using BugTracking.Business.ViewModels;
using BugTracking.Business.Dal;
using BugTracking.Database.Domain;
using AutoMapper;

namespace BugTracking.Business.Service.ProjectStatus
{
    public class ProjectStatusService : IProjectStatusService
    {
        private UnitOfWork unitOfWork;

        public void Create(Project_StatusViewModel model)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Project_Status modelMapping = Mapper.Map<Project_StatusViewModel, Project_Status>(model);
                unitOfWork.ProjectStatusReporitory.Insert(modelMapping);
                unitOfWork.ProjectStatusReporitory.Save();
            }
        }

        public void Delete(int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Project_Status model = unitOfWork.ProjectStatusReporitory.GetById(id);
                unitOfWork.ProjectStatusReporitory.Delete(model);
                unitOfWork.ProjectStatusReporitory.Save();
            }
        }

        public Project_StatusViewModel Get(int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Project_Status model = unitOfWork.ProjectStatusReporitory.GetById(id);
                Project_StatusViewModel modelMappig = Mapper.Map<Project_Status, Project_StatusViewModel>(model);

                modelMappig.ProjectViewModels = Mapper.Map<ICollection<Project>, ICollection<ProjectViewModel>>(model.Projects);

                return modelMappig;
            }
        }

        public List<Project_StatusViewModel> GetAll()
        {
            using (unitOfWork = new UnitOfWork())
            {
                List<Project_Status> model = unitOfWork.ProjectStatusReporitory.GetAll();
                List<Project_StatusViewModel> modelMapping = new List<Project_StatusViewModel>();

                for(int i = 0; i < model.Count; i++)
                {
                    Project_StatusViewModel status = Mapper.Map<Project_Status, Project_StatusViewModel>(model[i]);
                    status.ProjectViewModels = Mapper.Map<ICollection<Project>, ICollection<ProjectViewModel>>(model[i].Projects);

                    modelMapping.Add(status);
                }

                return modelMapping;
            }
        }
    }
}
