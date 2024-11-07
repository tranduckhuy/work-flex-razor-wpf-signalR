using WorkFlex.Infrastructure.Utils.Mail;
using WorkFlex.Web;
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

// Add services to the container.
builder.Services.AddServices();

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
