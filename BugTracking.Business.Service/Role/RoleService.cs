using AutoMapper;
using BugTracking.Business.Contracts.Services.Role;
using BugTracking.Business.Dal;
using BugTracking.Business.ViewModels;
using BugTracking.Database.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking.Business.Service.Role
{
    public class RoleService : IRoleService
    {
        public void Create(User_RolesViewModel model)
        {
            using(var unitOfWork = new UnitOfWork())
            {
                User_Roles modelMapping = Mapper.Map<User_RolesViewModel, User_Roles>(model);
                unitOfWork.RoleRepository.Insert(modelMapping);
                unitOfWork.RoleRepository.Save();
            }
        }

        public List<User_RolesViewModel> GetAll()
        {
            using(var unitOfWork = new UnitOfWork())
            {
                List<User_Roles> rolesList = unitOfWork.RoleRepository.GetAll() as List<User_Roles>;

                return Mapper.Map<List<User_Roles>, List<User_RolesViewModel>>(rolesList);
            }
        }
    }
}
