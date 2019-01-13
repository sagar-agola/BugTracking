using BugTracking.Business.Enums;

namespace BugTracking.Business.Models
{
    public class ResponseDetails
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public object Data { get; set; }
        public MessageType MessageType { get; set; }
    }
}
