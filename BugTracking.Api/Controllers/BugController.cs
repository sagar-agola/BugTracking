using BugTracking.Business.Contracts.Services.Bugs;
using BugTracking.Business.Enums;
using BugTracking.Business.Helpers;
using BugTracking.Business.Models;
using BugTracking.Business.Service.Bugs;
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

        public BugController()
        {
            bugService = new BugService();
        }

        [Route("create")]
        [HttpPost]
        public object CreateBug()
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                HttpRequest req = HttpContext.Current.Request;
                BugViewModel model = Helper.SaveBugImage(req);

                bugService.Create(model);
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
