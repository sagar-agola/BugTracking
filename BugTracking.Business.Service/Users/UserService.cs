using BugTracking.Business.Contracts.Services.Users;
using System.Collections.Generic;
using BugTracking.Business.ViewModels;
using BugTracking.Business.Dal;
using AutoMapper;
using BugTracking.Database.Domain;
using System.Linq;

namespace BugTracking.Business.Service.Users
{
    public class UserService : IUserService
    {
        private UnitOfWork unitOfWork;

        public void Create(UserViewModel model)
        {
            using(unitOfWork = new UnitOfWork())
            {
                User modelMapping = Mapper.Map<UserViewModel, User>(model);
                unitOfWork.UserRepository.Insert(modelMapping);
                unitOfWork.UserRepository.Save();
            }
        }

        public void Delete(int id)
        {
            using(unitOfWork = new UnitOfWork())
            {
                User user = unitOfWork.UserRepository.Get(id);
                unitOfWork.UserRepository.Delete(user);
                unitOfWork.UserRepository.Save();
            }
        }

        public void Edit(UserViewModel model)
        {
            using(unitOfWork = new UnitOfWork())
            {
                User modelMapping = Mapper.Map<UserViewModel, User>(model);
                unitOfWork.UserRepository.Update(modelMapping);
                unitOfWork.UserRepository.Save();
            }
        }

        public int EmployeeCount()
        {
            using (unitOfWork = new UnitOfWork())
            {
                return unitOfWork.UserRepository.EmployeeCount();
            }
        }

        public List<UserViewModel> GetAll()
        {
            using(unitOfWork = new UnitOfWork())
            {
                List<User> users = unitOfWork.UserRepository.GetAll();
                List<UserViewModel> userMapping = new List<UserViewModel>();

                for (int i = 0; i < users.Count; i++)
                {
                    userMapping.Add(MapUser(users[i]));
                }

                return userMapping;
            }
        }

        public UserViewModel GetById(int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                User user = unitOfWork.UserRepository.GetById(id);
                
                return MapUser(user);
            }
        }

        public List<UserViewModel> GetFreeUsers()
        {
            using (unitOfWork = new UnitOfWork())
            {
                List<User> model = unitOfWork.UserRepository.GetFreeEmployees();

                return Mapper.Map<List<User>, List<UserViewModel>>(model);
            }
        }

        private UserViewModel MapUser(User user)
        {
            UserViewModel userMapping = Mapper.Map<User, UserViewModel>(user);
            userMapping.User_RolesViewModel = Mapper.Map<User_Roles, User_RolesViewModel>(user.User_Roles);
            userMapping.BugViewModels = Mapper.Map<ICollection<Bug>, ICollection<BugViewModel>>(user.Bugs);

            List<Project_Developers> listModel = user.Project_Developers.ToList();
            List<Project_DevelopersViewModel> listModelMapping = new List<Project_DevelopersViewModel>();
            for(int i = 0; i < listModel.Count; i++)
            {
                listModelMapping.Add(MapProjectDeveloper(listModel[i]));
            }
            userMapping.Project_DevelopersViewModel = listModelMapping;

            return userMapping;
        }

        private Project_DevelopersViewModel MapProjectDeveloper(Project_Developers model)
        {
            Project_DevelopersViewModel modelMapping = Mapper.Map<Project_Developers, Project_DevelopersViewModel>(model);

            modelMapping.UserViewModel = Mapper.Map<User, UserViewModel>(model.User);
            modelMapping.ProjectViewModel = Mapper.Map<Project, ProjectViewModel>(model.Project);

            return modelMapping;
        }
    }
}
