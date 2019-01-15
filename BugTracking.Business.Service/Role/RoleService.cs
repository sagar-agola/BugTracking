using AutoMapper;
using BugTracking.Business.Contracts.Services.Role;
using BugTracking.Business.Dal;
using BugTracking.Business.ViewModels;
using BugTracking.Database.Domain;
using System.Collections.Generic;
using System.Linq;

namespace BugTracking.Business.Service.Role
{
    public class RoleService : IRoleService
    {
        private UnitOfWork unitOfWork;

        public void Create(User_RolesViewModel model)
        {
            using(unitOfWork = new UnitOfWork())
            {
                User_Roles modelMapping = Mapper.Map<User_RolesViewModel, User_Roles>(model);
                unitOfWork.RoleRepository.Insert(modelMapping);
                unitOfWork.RoleRepository.Save();
            }
        }

        public List<User_RolesViewModel> GetAll()
        {
            using(unitOfWork = new UnitOfWork())
            {
                List<User_Roles> rolesList = unitOfWork.RoleRepository.GetAll().ToList();

                return Mapper.Map<List<User_Roles>, List<User_RolesViewModel>>(rolesList);
            }
        }

        public void EditRole(User_RolesViewModel model)
        {
            using(unitOfWork = new UnitOfWork())
            {
                User_Roles modelMapping = Mapper.Map<User_RolesViewModel, User_Roles>(model);
                unitOfWork.RoleRepository.Update(modelMapping);
                unitOfWork.RoleRepository.Save();
            }
        }

        public void DeleteRole(int id)
        {
            using(unitOfWork = new UnitOfWork())
            {
                User_Roles model = unitOfWork.RoleRepository.Get(id);
                unitOfWork.RoleRepository.Delete(model);
                unitOfWork.RoleRepository.Save();
            }
        }
    }
}
