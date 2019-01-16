using System;
using System.Collections.Generic;

namespace BugTracking.Business.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            BugViewModels = new HashSet<BugViewModel>();
            Project_DevelopersViewModel = new HashSet<Project_DevelopersViewModel>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ContectNumber { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public DateTime BirthDate { get; set; }
        public int Experience { get; set; }
        public string Password { get; set; }

        public virtual ICollection<BugViewModel> BugViewModels { get; set; }
        public virtual ICollection<Project_DevelopersViewModel> Project_DevelopersViewModel { get; set; }
        public virtual User_RolesViewModel User_RolesViewModel { get; set; }
    }
}
