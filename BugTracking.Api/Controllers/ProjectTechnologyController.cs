using BugTracking.Business.Contracts.Services.ProjectTechnology;
using BugTracking.Business.Enums;
using BugTracking.Business.Helpers;
using BugTracking.Business.Models;
using BugTracking.Business.Service.ProjectTechnology;
using BugTracking.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace BugTracking.Api.Controllers
{
    [RoutePrefix("api/project/technology")]
    public class ProjectTechnologyController : ApiController
    {
        private readonly IProjectTechnologyService projectTechnologyService;

        public ProjectTechnologyController()
        {
            projectTechnologyService = new ProjectTechnologyService();
        }

        [Route("create")]
        [HttpPost]
        public object CreateTechnology(Project_TechnologiesViewModel mode)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                projectTechnologyService.Create(mode);
                responseDetails = Helper.SetResponseDetails("Technology created successfully.", true, null, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("get/{id}")]
        [HttpGet]
        public object GetTechnology(int id)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                Project_TechnologiesViewModel model = projectTechnologyService.Get(id);
                responseDetails = Helper.SetResponseDetails("", true, model, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("get-all")]
        [HttpGet]
        public object GetAll()
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                List<Project_TechnologiesViewModel> model = projectTechnologyService.GetAll();
                responseDetails = Helper.SetResponseDetails("", true, model, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public object DeleteTechnology(int id)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                projectTechnologyService.Delete(id);
                responseDetails = Helper.SetResponseDetails("Technology removed successfully.", true, null, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }
    }
}
