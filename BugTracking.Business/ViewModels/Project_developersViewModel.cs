namespace BugTracking.Business.ViewModels
{
    public class Project_DevelopersViewModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }

        public virtual ProjectViewModel ProjectViewModel { get; set; }
        public virtual UserViewModel UserViewModel { get; set; }
    }
}
