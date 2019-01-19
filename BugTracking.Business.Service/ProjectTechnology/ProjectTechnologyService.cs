using BugTracking.Business.Contracts.Services.ProjectTechnology;
using System.Collections.Generic;
using BugTracking.Business.ViewModels;
using BugTracking.Business.Dal;
using BugTracking.Database.Domain;
using AutoMapper;

namespace BugTracking.Business.Service.ProjectTechnology
{
    public class ProjectTechnologyService : IProjectTechnologyService
    {
        private UnitOfWork unitOfWork;

        public void Create(Project_TechnologiesViewModel model)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Project_Technologies modelMapping = Mapper.Map<Project_TechnologiesViewModel, Project_Technologies>(model);
                unitOfWork.ProjectTechnologyRepository.Insert(modelMapping);
                unitOfWork.ProjectTechnologyRepository.Save();
            }
        }

        public void Delete(int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Project_Technologies model = unitOfWork.ProjectTechnologyRepository.Get(id);
                unitOfWork.ProjectTechnologyRepository.Delete(model);
                unitOfWork.ProjectTechnologyRepository.Save();
            }
        }

        public Project_TechnologiesViewModel Get(int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Project_Technologies model = unitOfWork.ProjectTechnologyRepository.GetById(id);
                Project_TechnologiesViewModel modelMapping = Mapper.Map<Project_Technologies, Project_TechnologiesViewModel>(model);

                modelMapping.ProjectViewModels = Mapper.Map<ICollection<Project>, ICollection<ProjectViewModel>>(model.Projects);

                return modelMapping;
            }
        }

        public List<Project_TechnologiesViewModel> GetAll()
        {
            using (unitOfWork = new UnitOfWork())
            {
                List<Project_Technologies> model = unitOfWork.ProjectTechnologyRepository.GetAll();
                List<Project_TechnologiesViewModel> modelMapping = new List<Project_TechnologiesViewModel>();

                for (int i = 0; i < model.Count; i++)
                {
                    Project_TechnologiesViewModel tech = Mapper.Map<Project_Technologies, Project_TechnologiesViewModel>(model[i]);
                    tech.ProjectViewModels = Mapper.Map<ICollection<Project>, ICollection<ProjectViewModel>>(model[i].Projects);

                    modelMapping.Add(tech);
                }

                return modelMapping;
            }
        }
    }
}
