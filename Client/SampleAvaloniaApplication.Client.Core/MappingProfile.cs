using AutoMapper;
using SampleAvaloniaApplication.Client.Core.Data;
using SampleAvaloniaApplication.Client.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleAvaloniaApplication.Client.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClientEmployee, EmployeeModel>()
                .ReverseMap()
                .ForMember(dest => dest.Id, src => src.Ignore());
        }
    }
}
