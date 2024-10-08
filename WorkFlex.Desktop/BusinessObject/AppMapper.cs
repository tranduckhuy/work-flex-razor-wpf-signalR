using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlex.Desktop.BusinessObject
{
	public static class AppMapper
	{
		private readonly static Lazy<IMapper> _lazy = new Lazy<IMapper>(() =>
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<MapperProfile>();
			});
			return config.CreateMapper();
		});

		public static IMapper Mapper => _lazy.Value;
	}
}
