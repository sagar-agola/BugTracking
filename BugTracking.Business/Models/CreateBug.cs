using BugTracking.Business.ViewModels;
using System.Collections.Generic;

namespace BugTracking.Business.Models
{
    public class CreateBug
    {
        public List<ProjectViewModel> Projects { get; set; }

        public List<UserViewModel> Users { get; set; }

        public List<Bug_PrioritiesViewModel> Priorities { get; set; }

        public List<Bug_StatusViewModel> StatusList { get; set; }
    }
}
