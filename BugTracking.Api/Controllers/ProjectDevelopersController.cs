﻿using BugTracking.Business.Contracts.Repositories.ProjectDevelopers;
using BugTracking.Business.Contracts.Services.ProjectDevelopers;
using BugTracking.Business.Enums;
using BugTracking.Business.Helpers;
using BugTracking.Business.Models;
using BugTracking.Business.Service.ProjectDevelopers;
using BugTracking.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BugTracking.Api.Controllers
{
    [RoutePrefix("api/project-developers")]
    public class ProjectDevelopersController : ApiController
    {
        private readonly IProjectDevelopersService projectDevelopersService;

        public ProjectDevelopersController()
        {
            projectDevelopersService = new ProjectDevelopersService();
        }

        [HttpGet]
        [Route("get/{id}")]
        public object GetByProjectId(int id)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                List<Project_DevelopersViewModel> model = projectDevelopersService.GetbyProjectId(id);
                responseDetails = Helper.SetResponseDetails("", true, model, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception encountered : ", false, ex, MessageType.Error);
            }

            return responseDetails;
        }

        [HttpPost]
        [Route("add")]
        public object AddDeveloper(Project_DevelopersViewModel model)
        {
            ResponseDetails responseDetails = new ResponseDetails();

            try
            {
                projectDevelopersService.Create(model);
                responseDetails = Helper.SetResponseDetails("Developer added successfully.", true, null, MessageType.Success);
            }
            catch(Exception ex)
            {
                responseDetails = Helper.SetResponseDetails("Exception Encountered : ", false, ex, MessageType.Error);
            }

            return responseDetails;
        }
    }
}
