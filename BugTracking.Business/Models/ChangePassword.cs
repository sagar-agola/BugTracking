﻿namespace BugTracking.Business.Models
{
    public class ChangePassword
    {
        public int Id { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
