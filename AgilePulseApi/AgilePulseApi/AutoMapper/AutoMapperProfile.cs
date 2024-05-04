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
        }  
    }
}
