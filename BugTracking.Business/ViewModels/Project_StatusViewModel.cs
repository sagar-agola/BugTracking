using System.Collections.Generic;

namespace BugTracking.Business.ViewModels
{
    public class Project_StatusViewModel
    {
        public Project_StatusViewModel()
        {
            ProjectViewModels = new HashSet<ProjectViewModel>();
        }

        public int Id { get; set; }
        public string ProjectStatus { get; set; }

        public virtual ICollection<ProjectViewModel> ProjectViewModels { get; set; }
    }
}
