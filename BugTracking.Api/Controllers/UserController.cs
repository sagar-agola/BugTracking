using BugTracking.Business.Contracts.Services.Users;
using BugTracking.Business.Enums;
using BugTracking.Business.Helpers;
using BugTracking.Business.Models;
using BugTracking.Business.Service.Users;
using BugTracking.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace BugTracking.Api.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserService userService;

        public UserController()
        {
            userService = new UserService();
        }

        [Route("create")]
        [HttpPost]
        public object CreateUser(UserViewModel model)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                userService.Create(model);
                responseDetails = Helper.SetResponseDetails("User created successfully.", true, null, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("get/{id}")]
        [HttpGet]
        public object GetUserById(int id)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                UserViewModel user = userService.GetById(id);
                responseDetails = Helper.SetResponseDetails("", true, user, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("get-all")]
        [HttpGet]
        public object GetAllUser()
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                List<UserViewModel> users = userService.GetAll();
                responseDetails = Helper.SetResponseDetails("", true, users, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("update")]
        [HttpPut]
        public object UpdateUser(UserViewModel model)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                userService.Edit(model);
                responseDetails = Helper.SetResponseDetails("User details updated successfully.", true, null, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public object Deleteuser(int id)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                userService.Delete(id);
                responseDetails = Helper.SetResponseDetails("User removed successfully.", true, null, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }
    }
}
