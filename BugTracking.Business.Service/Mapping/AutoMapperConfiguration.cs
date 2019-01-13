using AutoMapper;
using BugTracking.Business.ViewModels;
using BugTracking.Database.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracking.Business.Service.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Bug_Status, Bug_StatusViewModel>();
            Mapper.CreateMap<Bug_StatusViewModel, Bug_Status>();
        }
    }
}
