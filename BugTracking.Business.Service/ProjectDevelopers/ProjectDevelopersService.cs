using AutoMapper;
using BugTracking.Business.Contracts.Services.ProjectDevelopers;
using BugTracking.Business.Dal;
using BugTracking.Business.ViewModels;
using BugTracking.Database.Domain;
using System.Collections.Generic;

namespace BugTracking.Business.Service.ProjectDevelopers
{
    public class ProjectDevelopersService : IProjectDevelopersService
    {
        private UnitOfWork unitOfWork;

        public void Create(Project_DevelopersViewModel model)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Project_Developers modelmapping = Mapper.Map<Project_DevelopersViewModel, Project_Developers>(model);
                unitOfWork.projectDevelopersRepository.Insert(modelmapping);
                unitOfWork.projectDevelopersRepository.Save();
            }
        }

        public List<Project_DevelopersViewModel> GetbyProjectId(int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                List<Project_Developers> model = unitOfWork.projectDevelopersRepository.GetByProjectId(id);
                List<Project_DevelopersViewModel> modelMapping = new List<Project_DevelopersViewModel>();

                for(int i = 0; i < model.Count; i++)
                {
                    modelMapping.Add(MapProjectDeveloper(model[i]));
                }

                return modelMapping;
            }
        }

        private Project_DevelopersViewModel MapProjectDeveloper(Project_Developers model)
        {
            Project_DevelopersViewModel modelMapping = Mapper.Map<Project_Developers, Project_DevelopersViewModel>(model);

            modelMapping.ProjectViewModel = Mapper.Map<Project, ProjectViewModel>(model.Project);
            modelMapping.UserViewModel = Mapper.Map<User, UserViewModel>(model.User);

            return modelMapping;
        }
    }
}
