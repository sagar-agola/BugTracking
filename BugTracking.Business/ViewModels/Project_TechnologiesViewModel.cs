using System.Collections.Generic;

namespace BugTracking.Business.ViewModels
{
    public class Project_TechnologiesViewModel
    {
        public Project_TechnologiesViewModel()
        {
            ProjectViewModels = new HashSet<ProjectViewModel>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProjectViewModel> ProjectViewModels { get; set; }
    }
}
