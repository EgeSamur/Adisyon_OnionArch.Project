using Adisyon_OnionArch.Project.Application;
using Adisyon_OnionArch.Project.Persistance;
using Adisyon_OnionArch.Project.Infrastracture;
using Adisyon_OnionArch.Project.CustomMapper;
using Serilog;
using Microsoft.OpenApi.Models; // Bu satýr, RegisterPersistance metodunu kullanmak için gerekli


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// launch settimgs'in ASPNETCORE_ENVIROMENT'ýný kontrol
var env = builder.Environment;

builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

// Persistance DPI'larý
builder.Services.RegisterPersistance(builder.Configuration);
// Application DPI'larý
builder.Services.RegisterApplication();
// Infrastracture DPI'larý
builder.Services.RegisterInfrastructure(builder.Configuration);
// CustomMapper DPI'larý
builder.Services.RegisterCustomMapper();


// Serilog'u yapýlandýr
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day) // Dosyaya yaz
    .CreateLogger();

builder.Host.UseSerilog(); // Serilog'u kullan



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Adisyon API", Version = "v1", Description = "Adisyon API" });
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Bearer yazýp boþluk býrak."
    });
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
            Reference = new OpenApiReference
                {
                 Type = ReferenceType.SecurityScheme,
                 Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.AddConfigureGlobalExceptionMiddleware();
app.UseAuthorization();

app.MapControllers();

app.Run();
