using BugTracking.Business.Contracts.Services.Bugs;
using BugTracking.Business.Contracts.Services.Projects;
using BugTracking.Business.Contracts.Services.Users;
using BugTracking.Business.Enums;
using BugTracking.Business.Helpers;
using BugTracking.Business.Models;
using BugTracking.Business.Service.Bugs;
using BugTracking.Business.Service.Projects;
using BugTracking.Business.Service.Users;
using System;
using System.Web.Http;

namespace BugTracking.Api.Controllers
{
    [RoutePrefix("api/dashboard")]
    public class DashboardController : ApiController
    {
        private readonly IBugService bugService;
        private readonly IProjectService projectService;
        private readonly IUserService userService;

        public DashboardController()
        {
            bugService = new BugService();
            projectService = new ProjectService();
            userService = new UserService();
        }

        [Route("system-overview")]
        [HttpGet]
        public object GetSystemOverView()
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                SystemOverview systemOverview = new SystemOverview
                {
                    BugCount = bugService.OpenBugCount(),
                    ProjectCount = projectService.ActiveProjectCount(),
                    EmployeeCount = userService.EmployeeCount()
                };

                responseDetails = Helper.SetResponseDetails("", true, systemOverview, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }
    }
}
