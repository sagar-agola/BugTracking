using AutoMapper;
using BugTracking.Business.ViewModels;
using BugTracking.Database.Domain;

namespace BugTracking.Business.Service.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Bug_Status, Bug_StatusViewModel>();
            Mapper.CreateMap<Bug_StatusViewModel, Bug_Status>();

            Mapper.CreateMap<User_Roles, User_RolesViewModel>();
            Mapper.CreateMap<User_RolesViewModel, User_Roles>();

            Mapper.CreateMap<User, UserViewModel>();
            Mapper.CreateMap<UserViewModel, User>();
        }
    }
}
