using BugTracking.Business.ViewModels;
using System.Collections.Generic;

namespace BugTracking.Business.Contracts.Services.Users
{
    public interface IUserService
    {
        void Create(UserViewModel model);

        List<UserViewModel> GetAll();

        UserViewModel GetById(int id);

        void Edit(UserViewModel model);

        void Delete(int id);

        int EmployeeCount();

        List<UserViewModel> GetFreeUsers();
    }
}
