using BugTracking.Business.Contracts.Services.Users;
using System.Collections.Generic;
using BugTracking.Business.ViewModels;
using BugTracking.Business.Dal;
using AutoMapper;
using BugTracking.Database.Domain;

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

        private UserViewModel MapUser(User user)
        {
            UserViewModel userMapping = Mapper.Map<User, UserViewModel>(user);
            userMapping.User_RolesViewModel = Mapper.Map<User_Roles, User_RolesViewModel>(user.User_Roles);
            userMapping.BugViewModels = Mapper.Map<ICollection<Bug>, ICollection<BugViewModel>>(user.Bugs);
            userMapping.Project_DevelopersViewModel = Mapper.Map<ICollection<Project_Developers>, ICollection<Project_DevelopersViewModel>>(user.Project_Developers);

            return userMapping;
        }
    }
}
