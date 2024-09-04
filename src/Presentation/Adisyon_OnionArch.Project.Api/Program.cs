using Adisyon_OnionArch.Project.Application;
using Adisyon_OnionArch.Project.Persistance;
using Serilog; // Bu satýr, RegisterPersistance metodunu kullanmak için gerekli


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


// Serilog'u yapýlandýr
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day) // Dosyaya yaz
    .CreateLogger();

builder.Host.UseSerilog(); // Serilog'u kullan


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
