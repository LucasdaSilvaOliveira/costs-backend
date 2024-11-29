using AutoMapper;
using costs_api.Database.Entities;
using costs_api.DTOs.Project;
using costs_api.DTOs.Service;
using Microsoft.Extensions.WebEncoders.Testing;

namespace costs_api.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Project, ProjectDTO>().ReverseMap();

            CreateMap<Service, ServiceDTO>()
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name));

            CreateMap<ServiceDTO, Service>();
        }
    }
}
