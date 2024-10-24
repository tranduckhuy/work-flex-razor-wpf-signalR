using WorkFlex.Domain.Entities;
using WorkFlex.Services.DTOs;


namespace WorkFlex.Desktop.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<JobPost, JobPostDto>().ReverseMap();
        }
    }
}
