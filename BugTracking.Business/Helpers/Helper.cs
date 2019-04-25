using BugTracking.Business.Enums;
using BugTracking.Business.Models;
using BugTracking.Business.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Web;

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

        public static BugViewModel SaveBugImage(HttpRequest req)
        {
            string imageName = null;
            var image = req.Files["file"];

            imageName = new string(Path.GetFileNameWithoutExtension(image.FileName).Take(10).ToArray())
                .Replace(" ", "-");
            imageName += DateTime.Now.ToString("yymmssfff") + Path.GetExtension(image.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/BugImages/" + imageName);
            image.SaveAs(filePath);

            return new BugViewModel()
            {
                Title = req.Form["Title"],
                Description = req.Form["Description"],
                ProjectId = int.Parse(req.Form["ProjectId"]),
                UserId = int.Parse(req.Form["UserId"]),
                PriorityId = int.Parse(req.Form["PriorityId"]),
                StatusId = int.Parse(req.Form["StatusId"]),
                ImageUrl = imageName
            };
        }
    }
}
