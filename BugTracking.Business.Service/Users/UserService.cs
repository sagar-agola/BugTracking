using BugTracking.Business.Contracts.Services.Users;
using System.Collections.Generic;
using System.Linq;
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
                List<User> users = unitOfWork.UserRepository.GetAll().ToList();

                return Mapper.Map<List<User>, List<UserViewModel>>(users);
            }
        }

        public UserViewModel GetById(int id)
        {
            using (unitOfWork = new UnitOfWork())
            {
                User user = unitOfWork.UserRepository.Get(id);

                return Mapper.Map<User, UserViewModel>(user);
            }
        }
    }
}
