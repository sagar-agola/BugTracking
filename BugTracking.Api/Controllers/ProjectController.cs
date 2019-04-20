using BugTracking.Business.Contracts.Services.Projects;
using BugTracking.Business.Enums;
using BugTracking.Business.Helpers;
using BugTracking.Business.Models;
using BugTracking.Business.Service.Projects;
using BugTracking.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace BugTracking.Api.Controllers
{
    [RoutePrefix("api/project")]
    public class ProjectController : ApiController
    {
        private readonly IProjectService projectService;

        public ProjectController()
        {
            projectService = new ProjectService();
        }

        [Route("create")]
        [HttpPost]
        public object CreateProject(ProjectViewModel model)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                projectService.Create(model);
                responseDetails = Helper.SetResponseDetails("Project created successfully.", true, null, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("change-status")]
        [HttpPost]
        public object ChangeStatus(ChangeStatus model)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                ProjectViewModel project = projectService.Get(model.Id);
                project.ProjectStatusId = model.StatusId;

                projectService.Update(project);

                responseDetails = Helper.SetResponseDetails("Project status updated successfully.", true, null, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("get/{id}")]
        [HttpGet]
        public object GetProject(int id)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                ProjectViewModel model = projectService.Get(id);
                responseDetails = Helper.SetResponseDetails("", true, model, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("get-all")]
        [HttpGet]
        public object GetAllProject()
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                List<ProjectViewModel> model = projectService.GetAll();
                responseDetails = Helper.SetResponseDetails("", true, model, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("update")]
        [HttpPut]
        public object UpdateProject(ProjectViewModel model)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                projectService.Update(model);
                responseDetails = Helper.SetResponseDetails("Project updated successfully.", true, null, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public object DeleteProject(int id)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                projectService.Delete(id);
                responseDetails = Helper.SetResponseDetails("Project removed successfully.", true, null, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }
    }
}
