using BugTracking.Business.Contracts.Services.ProjectStatus;
using BugTracking.Business.Enums;
using BugTracking.Business.Helpers;
using BugTracking.Business.Models;
using BugTracking.Business.Service.ProjectStatus;
using BugTracking.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace BugTracking.Api.Controllers
{
    [RoutePrefix("api/project/status")]
    public class ProjectStatusController : ApiController
    {
        private readonly IProjectStatusService projectStatusService;

        public ProjectStatusController()
        {
            projectStatusService = new ProjectStatusService();
        }

        [Route("create")]
        [HttpPost]
        public object CreateStatus(Project_StatusViewModel model)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                projectStatusService.Create(model);
                responseDetails = Helper.SetResponseDetails("Status created successfully.", true, null, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encuntered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("get/{id}")]
        [HttpGet]
        public object GetStatus(int id)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                Project_StatusViewModel model = projectStatusService.Get(id);
                responseDetails = Helper.SetResponseDetails("", true, model, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encuntered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("get-all")]
        [HttpGet]
        public object GetAllStatus()
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                List<Project_StatusViewModel> model = projectStatusService.GetAll();
                responseDetails = Helper.SetResponseDetails("", true, model, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encuntered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public object DeleteStatus(int id)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                projectStatusService.Delete(id);
                responseDetails = Helper.SetResponseDetails("Status removed successfully.", true, null, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encuntered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }
    }
}
