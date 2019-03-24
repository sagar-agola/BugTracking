using AutoMapper;
using BugTracking.Business.ViewModels;
using BugTracking.Database.Domain;

namespace BugTracking.Business.Service.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<User, UserViewModel>();
            Mapper.CreateMap<UserViewModel, User>();

            Mapper.CreateMap<User_Roles, User_RolesViewModel>();
            Mapper.CreateMap<User_RolesViewModel, User_Roles>();

            Mapper.CreateMap<Bug, BugViewModel>();
            Mapper.CreateMap<BugViewModel, Bug>();

            Mapper.CreateMap<Bug_Status, Bug_StatusViewModel>();
            Mapper.CreateMap<Bug_StatusViewModel, Bug_Status>();

            Mapper.CreateMap<Bug_PrioritiesViewModel, Bug_priorities>();
            Mapper.CreateMap<Bug_priorities, Bug_PrioritiesViewModel>();

            Mapper.CreateMap<Project_Status, Project_StatusViewModel>();
            Mapper.CreateMap<Project_StatusViewModel, Project_Status>();

            Mapper.CreateMap<Project_Technologies, Project_TechnologiesViewModel>();
            Mapper.CreateMap<Project_TechnologiesViewModel, Project_Technologies>();

            Mapper.CreateMap<Project_Developers, Project_DevelopersViewModel>();
            Mapper.CreateMap<Project_DevelopersViewModel, Project_Developers>();

            Mapper.CreateMap<Project, ProjectViewModel>();
            Mapper.CreateMap<ProjectViewModel, Project>();
        }
    }
}
