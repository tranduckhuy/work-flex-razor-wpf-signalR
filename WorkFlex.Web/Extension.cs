using WorkFlex.Domain.Repositories;
using WorkFlex.Infrastructure.Data;
using WorkFlex.Infrastructure.Repositories;
using WorkFlex.Infrastructure.Utils.Helper;
using WorkFlex.Infrastructure.Utils.Helper.Interface;
using WorkFlex.Services;
using WorkFlex.Services.Interface;
using WorkFlex.Web.Mapping;
using WorkFlex.Web.Untils.Helper;
using WorkFlex.Web.Untils.Helper.Interface;
using WorkFlex.Web.Utils.Helper;
using WorkFlex.Web.Utils.Helper.Interface;

namespace WorkFlex.Web
{
    public static class Extension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            // Mapper Register
            services.AddAutoMapper(typeof(MappingProfile));

            // DBContext Register
            services.AddDbContext<AppDbContext>();

            // Repositories Register
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IJobApplyRepository, JobApplyRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();

			// Helpers Register
			services.AddScoped<IEmailHelper, EmailHelper>();
            services.AddScoped<IJobFilterHelper, JobFilterHelper>();
            services.AddScoped<IAddressHelper, AddressHelper>();

            // Services Register
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenService, AuthenService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IConversationService, ConversationService>();
            services.AddScoped<IJobApplyService, JobApplyService>();
            services.AddScoped<IDashboardService, DashboardService>();

			return services;
        }
    }
}
