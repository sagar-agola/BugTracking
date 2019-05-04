using BugTracking.Business.Contracts.Services.Bugs;
using BugTracking.Business.Contracts.Services.Projects;
using BugTracking.Business.Enums;
using BugTracking.Business.Helpers;
using BugTracking.Business.Models;
using BugTracking.Business.Service.Bugs;
using BugTracking.Business.Service.Projects;
using BugTracking.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace BugTracking.Api.Controllers
{
    [RoutePrefix("api/bug")]
    public class BugController : ApiController
    {
        private readonly IBugService bugService;
        private readonly IProjectService projectService;

        public BugController()
        {
            bugService = new BugService();
            projectService = new ProjectService();
        }

        [Route("create")]
        [HttpPost]
        public object CreateBug()
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                BugViewModel model = Helper.SaveBugImage(HttpContext.Current.Request);
                bugService.Create(model);

                // when creating bug we need to change project status to under development
                ProjectViewModel project = projectService.Get(model.ProjectId);
                project.ProjectStatusId = 1004;
                projectService.Update(project);

                responseDetails = Helper.SetResponseDetails("Bug created successfully.", true, null, MessageType.Success);
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
                BugViewModel bug = bugService.Get(model.Id);
                bug.StatusId = model.StatusId;

                if(model.StatusId == 2004)
                {
                    // if you are changing bug status to open => we need to change project status to under development
                    ProjectViewModel project = projectService.Get(bug.ProjectId);
                    project.ProjectStatusId = 1004;
                    projectService.Update(project);
                }
                else if(model.StatusId == 2005)
                {
                    // if you are changing bug status to Fixed => we need to change project status to under finished
                    ProjectViewModel project = projectService.Get(bug.ProjectId);
                    project.ProjectStatusId = 1007;
                    projectService.Update(project);
                }

                bugService.Update(bug);

                responseDetails = Helper.SetResponseDetails("Bug status updated successfully.", true, null, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("get/{id}")]
        [HttpGet]
        public object Get(int id)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                BugViewModel bugList = bugService.Get(id);
                responseDetails = Helper.SetResponseDetails("", true, bugList, MessageType.Success);
            }
            catch (Exception ex)
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
                List<BugViewModel> bugList = bugService.GetAll();
                responseDetails = Helper.SetResponseDetails("", true, bugList, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("get-data-for-create-bug")]
        [HttpGet]
        public object GetDataForCreateBug()
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                CreateBug model = bugService.GetDataForCreateBug();
                responseDetails = Helper.SetResponseDetails("", true, model, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("get-by-user/{id}")]
        [HttpGet]
        public object GetByUser(int id)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                List<BugViewModel> bugList = bugService.GetByUserId(id);
                responseDetails = Helper.SetResponseDetails("", true, bugList, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("get-for-tester")]
        [HttpGet]
        public object GetByUser()
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                List<BugViewModel> bugList = bugService.GetForTester();
                responseDetails = Helper.SetResponseDetails("", true, bugList, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("update/{id}")]
        [HttpPut]
        public object Update(BugViewModel model)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                bugService.Update(model);
                responseDetails = Helper.SetResponseDetails("Bug updated successfully.", true, null, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public object DeleteBug(int id)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                bugService.Delete(id);
                responseDetails = Helper.SetResponseDetails("Bug deleted successfully.", true, null, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }
    }
}
