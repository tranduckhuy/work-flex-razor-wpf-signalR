using WorkFlex.Domain.Entities;
using WorkFlex.Web.DTOs;

namespace WorkFlex.Web.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
