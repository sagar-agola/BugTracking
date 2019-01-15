using BugTracking.Business.ViewModels;
using System.Collections.Generic;

namespace BugTracking.Business.Contracts.Services.Role
{
    public interface IRoleService
    {
        void Create(User_RolesViewModel model);

        List<User_RolesViewModel> GetAll();

        void EditRole(User_RolesViewModel model);

        void DeleteRole(int id);
    }
}
