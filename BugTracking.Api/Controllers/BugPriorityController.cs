using BugTracking.Business.Contracts.Services.BugPriority;
using BugTracking.Business.Enums;
using BugTracking.Business.Helpers;
using BugTracking.Business.Models;
using BugTracking.Business.Service.BugPriority;
using BugTracking.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace BugTracking.Api.Controllers
{
    [RoutePrefix("api/bug/priority")]
    public class BugPriorityController : ApiController
    {
        private readonly IBugPriorityService bugPriorityService;

        public BugPriorityController()
        {
            bugPriorityService = new BugPriorityService();
        }

        [Route("create")]
        [HttpPost]
        public object CreatePriority(Bug_PrioritiesViewModel model)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                bugPriorityService.Create(model);
                responseDetails = Helper.SetResponseDetails("Bug priority inserted successfully.", true, null, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("get-all")]
        [HttpGet]
        public object GetAllBugPriorities()
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                List<Bug_PrioritiesViewModel> bugPrioritiesList = bugPriorityService.GetAll();
                responseDetails = Helper.SetResponseDetails("", true, bugPrioritiesList, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("update")]
        [HttpPut]
        public object UpdateBugPriority(Bug_PrioritiesViewModel model)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                bugPriorityService.Update(model);
                responseDetails = Helper.SetResponseDetails("Bug priority updated successfully.", true, null, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public object DeleteBugPriority(int id)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                bugPriorityService.Delete(id);
                responseDetails = Helper.SetResponseDetails("Bug Priority removed successfully.", false, null, MessageType.Success);
            }
            catch (Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }
    }
}
