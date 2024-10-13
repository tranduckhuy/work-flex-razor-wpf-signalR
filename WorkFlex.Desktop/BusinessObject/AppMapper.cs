using AutoMapper;

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
