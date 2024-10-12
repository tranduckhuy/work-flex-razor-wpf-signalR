using WorkFlex.Desktop.BusinessObject.DTO;
using WorkFlex.Domain.Entities;


namespace WorkFlex.Desktop.BusinessObject
{
    public class MapperProfile : AutoMapper.Profile
	{
		public MapperProfile() {
			CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Industry, IndustryDTO>().ReverseMap();
            CreateMap<JobPost, JobPostDTO>().ReverseMap();
            CreateMap<JobType, JobTypeDTO>().ReverseMap();

        }
	}
}
