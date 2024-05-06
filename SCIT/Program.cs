
using Microsoft.EntityFrameworkCore;
using SCIT.Data;
using SCIT.Interfaces;
using SCIT.Repositories;
using SCIT.Services;
using System.Runtime.InteropServices;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
string[] _allowedOrigins;

var builder = WebApplication.CreateBuilder(args);



if (!builder.Environment.IsDevelopment())
{
    var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    var basePath = isWindows ? @"C:\opt" : @"/var/pct";
    builder.Configuration.SetBasePath(basePath)
        .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();
}
else
{
    builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();
}
var configuration = builder;

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add services to the container.
builder.Services.AddScoped<IProgrammesRepository, ProgrammesRepository>();
builder.Services.AddScoped<ProgrammesService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

_allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins(_allowedOrigins).AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();

app.Run();
