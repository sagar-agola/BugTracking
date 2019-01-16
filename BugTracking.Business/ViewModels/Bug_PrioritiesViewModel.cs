using System.Collections.Generic;

namespace BugTracking.Business.ViewModels
{
    public class Bug_PrioritiesViewModel
    {
        public Bug_PrioritiesViewModel()
        {
            BugViewModels = new HashSet<BugViewModel>();
        }

        public int Id { get; set; }
        public string BugStatus { get; set; }

        public virtual ICollection<BugViewModel> BugViewModels { get; set; }
    }
}
