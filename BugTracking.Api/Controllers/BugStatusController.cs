using BugTracking.Business.Contracts.Services.BugStatus;
using BugTracking.Business.Enums;
using BugTracking.Business.Helpers;
using BugTracking.Business.Models;
using BugTracking.Business.Service.BugStatus;
using BugTracking.Business.ViewModels;
using System;
using System.Web.Http;

namespace BugTracking.Api.Controllers
{
    [RoutePrefix("api/bug/status")]
    public class BugStatusController : ApiController
    {
        #region Properties
        private readonly IBugStatusService statusService;
        #endregion

        #region Constructor
        public BugStatusController()
        {
            statusService = new BugStatusService();
        }
        #endregion

        [Route("create")]
        [HttpPost]
        public object CreateStatus(Bug_StatusViewModel model)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                statusService.Create(model);
                responseDetails = Helper.SetResponseDetails("Status inserted successfully.", true, null, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }
            return responseDetails;
        }
    }
}
