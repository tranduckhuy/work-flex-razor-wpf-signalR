using WorkFlex.Infrastructure.Data;
using WorkFlex.Web.Mapping;
using WorkFlex.Web.Repository;
using WorkFlex.Web.Repository.Interface;
using WorkFlex.Web.Services;
using WorkFlex.Web.Services.Interface;
using WorkFlex.Web.Untils.Helper.Interface;
using WorkFlex.Web.Untils.Helper;
using WorkFlex.Web.Untils.Mail;
using WorkFlex.Web.Utils.Helper.Interface;
using WorkFlex.Web.Utils.Helper;
using WorkFlex.Web.AuthenticationFilter;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
	options.Conventions.AddFolderApplicationModelConvention("/Dashboard", model =>
	{
		model.Filters.Add(new Filter());
	});

	options.Conventions.AddFolderApplicationModelConvention("/User", model =>
    {
        model.Filters.Add(new Filter());
    });

	options.Conventions.AddFolderApplicationModelConvention("/Recruiter", model =>
	{
		model.Filters.Add(new Filter());
	});
});

// Mapper Register
builder.Services.AddAutoMapper(typeof(MappingProfile));

// DBContext Register
builder.Services.AddDbContext<AppDbContext>();

// Repositories Register
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
// Services Register
builder.Services.AddScoped<IAuthenService, AuthenService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IConversationService, ConversationService>();
// Helpers Register
builder.Services.AddScoped<IEmailHelper, EmailHelper>();
builder.Services.AddScoped<IJobFilterHelper, JobFilterHelper>();
builder.Services.AddScoped<IAddressHelper, AddressHelper>();


builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<SendMailUtil>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
