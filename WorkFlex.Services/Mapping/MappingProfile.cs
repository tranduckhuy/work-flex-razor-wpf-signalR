using WorkFlex.Domain.Entities;
using WorkFlex.Services.DTOs;

namespace WorkFlex.Services.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Conversation, ConversationDto>().ReverseMap();
            CreateMap<JobPost, JobPostDto>().ReverseMap();
            CreateMap<JobApplication, JobApplicantDto>().ReverseMap();
        }
    }
}
