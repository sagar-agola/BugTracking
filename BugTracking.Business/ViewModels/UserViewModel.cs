using System;

namespace BugTracking.Business.ViewModels
{
    public class UserViewModel
    {
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
    }
}
