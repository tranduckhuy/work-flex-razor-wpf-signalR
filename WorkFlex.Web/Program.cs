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


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IAuthenService, AuthenService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IConversationService, ConversationService>();
builder.Services.AddScoped<IEmailHelper, EmailHelper>();
builder.Services.AddScoped<IJobFilterHelper, JobFilterHelper>();


builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<SendMailUtil>();


builder.Services.AddAuthentication("AuthScheme")
    .AddCookie("AuthScheme", options =>
    {
        options.LoginPath = "/TestLogin";
    });

builder.Services.AddDbContext<AppDbContext>();

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
