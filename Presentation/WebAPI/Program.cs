using WebAPI.Extensions.Microsoft;
using Persistence.Extensions.Microsoft;
using NLog;
using Application.Services.Logging;
using WebAPI.Extensions;
using Application.Features.CQRS.Handlers.BannerHandlers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure DBContext

builder.Services.ConfigureDbContext(builder.Configuration);

builder.Services.ConfigurePersistenceDependencies();

// CQRS registration to IoC  (Commands & Queries Handlers)
builder.Services.AddCQRSServices();

builder.Services.AddScoped<GetAllBannersQueryHandler>();

// LoggerService : Nlog
builder.Services.ConfigureLoggerService();
LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

//AutoMapper

builder.Services.ConfigureAutoMapper();


var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerService>();

app.ConfigureExceptionHandler(logger);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
