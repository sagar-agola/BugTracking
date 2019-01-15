using BugTracking.Business.Contracts.Services.Role;
using BugTracking.Business.Enums;
using BugTracking.Business.Helpers;
using BugTracking.Business.Models;
using BugTracking.Business.Service.Role;
using BugTracking.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace BugTracking.Api.Controllers
{
    [RoutePrefix("api/role")]
    public class RoleController : ApiController
    {
        private readonly IRoleService roleService;

        public RoleController()
        {
            roleService = new RoleService();
        }

        [Route("create")]
        [HttpPost]
        public object CreateRole(User_RolesViewModel model)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                roleService.Create(model);
                responseDetails = Helper.SetResponseDetails("Status inserted successfully.", true, null, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("get-all")]
        [HttpGet]
        public object GetAllRoles()
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                List<User_RolesViewModel> roles = roleService.GetAll();
                responseDetails = Helper.SetResponseDetails("", true, roles, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails =  Helper.SetResponseDetails("Exception Encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("edit")]
        [HttpPut]
        public object UpdateRole(User_RolesViewModel model)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                roleService.EditRole(model);
                responseDetails = Helper.SetResponseDetails("Updated successfully.", true, null, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public object DeleteRole(int id)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                roleService.DeleteRole(id);
                responseDetails = Helper.SetResponseDetails("Role removed successfully.", true, null, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : " + ex.Message, false, ex, MessageType.Error);
            }

            return responseDetails;
        }
    }
}
