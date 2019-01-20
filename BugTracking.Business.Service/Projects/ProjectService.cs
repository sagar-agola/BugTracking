using BugTracking.Business.Contracts.Services.Projects;
using System.Collections.Generic;
using BugTracking.Business.ViewModels;
using BugTracking.Business.Dal;
using BugTracking.Database.Domain;
using AutoMapper;

namespace BugTracking.Business.Service.Projects
{
    public class ProjectService : IProjectService
    {
        private UnitOfWork unitOfWork;

        public void Create(ProjectViewModel model)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Project modelMapping = Mapper.Map<ProjectViewModel, Project>(model);
                unitOfWork.ProjectRepository.Insert(modelMapping);
                unitOfWork.ProjectRepository.Save();
            }
        }

        public void Delete(int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Project model = unitOfWork.ProjectRepository.Get(id);
                unitOfWork.ProjectRepository.Delete(model);
                unitOfWork.ProjectRepository.Save();
            }
        }

        public ProjectViewModel Get(int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Project model = unitOfWork.ProjectRepository.GetById(id);

                return MapProjectModel(model);
            }
        }

        public List<ProjectViewModel> GetAll()
        {
            using (unitOfWork = new UnitOfWork())
            {
                List<Project> model = unitOfWork.ProjectRepository.GetAll();
                List<ProjectViewModel> modelMapping = new List<ProjectViewModel>();

                for(int i = 0; i < model.Count; i++)
                {
                    modelMapping.Add(MapProjectModel(model[i]));
                }

                return modelMapping;
            }
        }

        public void Update(ProjectViewModel model)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Project modelMapping = Mapper.Map<ProjectViewModel, Project>(model);
                unitOfWork.ProjectRepository.Update(modelMapping);
                unitOfWork.ProjectRepository.Save();
            }
        }

        private ProjectViewModel MapProjectModel(Project model)
        {
            ProjectViewModel modelMapping = Mapper.Map<Project, ProjectViewModel>(model);

            modelMapping.BugViewModels = Mapper.Map<ICollection<Bug>, ICollection<BugViewModel>>(model.Bugs);
            modelMapping.Project_DeveloperViewModels = Mapper.Map<ICollection<Project_Developers>, ICollection<Project_DevelopersViewModel>>(model.Project_Developers);
            modelMapping.Project_StatusViewModel = Mapper.Map<Project_Status, Project_StatusViewModel>(model.Project_Status);
            modelMapping.Project_TechnologiesViewModel = Mapper.Map<Project_Technologies, Project_TechnologiesViewModel>(model.Project_Technologies);

            return modelMapping;
        }
    }
}
