using AutoMapper;

namespace WorkFlex.Payment.Utils.Mappers
{
    public static class AppMapper
    {
        private readonly static Lazy<IMapper> _lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            return config.CreateMapper();
        });

        public static IMapper Mapper => _lazy.Value;
    }
}
