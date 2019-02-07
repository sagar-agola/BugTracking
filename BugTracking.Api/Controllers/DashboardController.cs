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

        [Route("bug-count")]
        [HttpGet]
        public object GetOpenBugCount()
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                int count = bugService.OpenBugCount();
                responseDetails = Helper.SetResponseDetails("", true, count, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("project-count")]
        [HttpGet]
        public object GetActiveProjectCount()
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                int count = projectService.ActiveProjectCount();
                responseDetails = Helper.SetResponseDetails("", true, count, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("employee-count")]
        [HttpGet]
        public object GetEmployeeCount()
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                int count = userService.EmployeeCount();
                responseDetails = Helper.SetResponseDetails("", true, count, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }
    }
}
