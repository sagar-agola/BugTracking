namespace BugTracking.Business.ViewModels
{
    public class BugViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }

        public virtual Bug_PrioritiesViewModel Bug_PrioritiesViewModel { get; set; }
        public virtual Bug_StatusViewModel Bug_StatusViewModel { get; set; }
        public virtual ProjectViewModel ProjectViewModel { get; set; }
        public virtual UserViewModel UserViewModel { get; set; }

    }
}
