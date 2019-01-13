using BugTracking.Business.Enums;
using BugTracking.Business.Models;

namespace BugTracking.Business.Helpers
{
    public static class Helper
    {
        public static ResponseDetails SetResponseDetails(string message, bool success, object data, MessageType messageType)
        {
            return new ResponseDetails()
            {
                Message = message,
                Success = success,
                Data = data,
                MessageType = messageType,
            };
        }
    }
}
