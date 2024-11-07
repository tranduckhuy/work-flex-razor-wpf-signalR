using WorkFlex.Payment.Configs.Momo;
using WorkFlex.Payment.Services;
using WorkFlex.Infrastructure.Data;
using WorkFlex.Payment.Configs.ZaloPay.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Version = "v1",
        Title = "WorkFlex Payment Api",
        Description = "WorkFlex Payment Api Documentation",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
        {
            Name = "WorkFlex",
            Url = new Uri("https://github.com/tranduckhuy/work-flex-razor-wpf-signalR")
        }
    });
});

builder.Services.Configure<MomoConfig>(builder.Configuration.GetSection(MomoConfig.ConfigName));
builder.Services.Configure<ZaloPayConfig>(builder.Configuration.GetSection(ZaloPayConfig.ConfigName));

builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("WorkFlex.Web", policy =>
    {
        policy.WithOrigins("https://localhost:7175")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("WorkFlex.Web");

app.MapControllers();


await app.RunAsync();
