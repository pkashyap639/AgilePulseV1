using AgilePulseApi.Models.Domain;
using AgilePulseApi.Models.DTO;
using AutoMapper;

namespace AgilePulseApi.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<ScrumUser, AddScrumUser>().ReverseMap();
            CreateMap<ScrumUser, ScrumUserDto>().ReverseMap();
            CreateMap<Project, AddProjectDto>().ReverseMap();
            CreateMap<Project, GetProjectsDto>().ReverseMap();
            CreateMap<ScrumUserProject, OnlyProjectDTO>().ReverseMap();
            CreateMap<Issue, AddIssueDTO>().ReverseMap();
            CreateMap<Issue, GetIssueDTO>().ReverseMap();
        }  
    }
}
