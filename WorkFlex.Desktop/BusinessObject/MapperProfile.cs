using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlex.Domain.Entities;


namespace WorkFlex.Desktop.BusinessObject
{
	public class MapperProfile : AutoMapper.Profile
	{
		public MapperProfile() {
			CreateMap<User, UserDTO>().ReverseMap();
		}
	}
}
