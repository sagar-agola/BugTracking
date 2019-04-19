using AutoMapper;
using BugTracking.Business.Contracts.Services.ProjectDevelopers;
using BugTracking.Business.Dal;
using BugTracking.Business.ViewModels;
using BugTracking.Database.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Project_DevelopersViewModel GetbyUserId(int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                Project_Developers model = unitOfWork.projectDevelopersRepository.GetByUserId(id);

                return MapProjectDeveloper(model);
            }
        }

        public void RemoveDeveloper(int projId, int devId)
        {
            using (unitOfWork = new UnitOfWork())
            {
                unitOfWork.projectDevelopersRepository.RemoveDeveloper(projId, devId);
                unitOfWork.projectDevelopersRepository.Save();
            }
        }

        private Project_DevelopersViewModel MapProjectDeveloper(Project_Developers model)
        {
            Project_DevelopersViewModel modelMapping = Mapper.Map<Project_Developers, Project_DevelopersViewModel>(model);

            modelMapping.ProjectViewModel = MapProject(model.Project);
            modelMapping.UserViewModel = Mapper.Map<User, UserViewModel>(model.User);

            return modelMapping;
        }

        private ProjectViewModel MapProject(Project model)
        {
            ProjectViewModel modelMapping = Mapper.Map<Project, ProjectViewModel>(model);

            modelMapping.BugViewModels = Mapper.Map<ICollection<Bug>, ICollection<BugViewModel>>(model.Bugs);
            modelMapping.Project_StatusViewModel = Mapper.Map<Project_Status, Project_StatusViewModel>(model.Project_Status);
            modelMapping.Project_TechnologiesViewModel = Mapper.Map<Project_Technologies, Project_TechnologiesViewModel>(model.Project_Technologies);

            List<Project_Developers> modelList = model.Project_Developers.ToList();
            List<Project_DevelopersViewModel> modelMappingList = new List<Project_DevelopersViewModel>();

            for(int i = 0; i < modelList.Count; i++)
            {
                modelMappingList.Add(MapInnerProjectDeveloper(modelList[i]));
            }

            modelMapping.Project_DeveloperViewModels = modelMappingList;

            return modelMapping;
        }

        private Project_DevelopersViewModel MapInnerProjectDeveloper(Project_Developers model)
        {
            Project_DevelopersViewModel modelMapping = Mapper.Map<Project_Developers, Project_DevelopersViewModel>(model);

            modelMapping.UserViewModel = Mapper.Map<User, UserViewModel>(model.User);

            return modelMapping;
        }
    }
}
