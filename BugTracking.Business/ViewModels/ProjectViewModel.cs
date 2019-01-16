using System.Collections.Generic;

namespace BugTracking.Business.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel()
        {
            BugViewModels = new HashSet<BugViewModel>();
            Project_DeveloperViewModels = new HashSet<Project_DevelopersViewModel>();
        }

        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public int TechnologyId { get; set; }
        public bool IsActive { get; set; }
        public int ProjectStatusId { get; set; }

        public virtual ICollection<BugViewModel> BugViewModels { get; set; }
        public virtual ICollection<Project_DevelopersViewModel> Project_DeveloperViewModels { get; set; }
        public virtual Project_StatusViewModel Project_StatusViewModel { get; set; }
        public virtual Project_TechnologiesViewModel Project_TechnologiesViewModel { get; set; }
    }
}
