using WorkFlex.Domain.Filters;
using WorkFlex.Services.DTOs;
using WorkFlex.Web.ViewModels;

namespace WorkFlex.Web.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginReqVM, LoginReqDto>().ReverseMap();
            CreateMap<RegisterVM, RegisterDto>().ReverseMap();
            CreateMap<UserMessageVM, UserMessageDto>().ReverseMap();
            CreateMap<JobPostVM, JobFilter>().ReverseMap();
            CreateMap<ConversationReplyViewModel, ConversationReplyDto>().ReverseMap();
            CreateMap<UserDto, UserVM>().ReverseMap();
        }
    }
}
