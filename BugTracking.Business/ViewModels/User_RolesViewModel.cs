using System.Collections.Generic;

namespace BugTracking.Business.ViewModels
{
    public class User_RolesViewModel
    {
        public User_RolesViewModel()
        {
            UserViewModels = new HashSet<UserViewModel>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<UserViewModel> UserViewModels { get; set; }
    }
}
