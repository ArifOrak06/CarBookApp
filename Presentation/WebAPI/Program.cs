using Application.Features.CQRS.Handlers.BannerHandlers;
using Application.Services.Logging;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Persistence.Extensions.Microsoft;
using WebAPI.ActionFilters;
using WebAPI.Extensions;
using WebAPI.Extensions.Microsoft;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure DBContext

builder.Services.ConfigureDbContext(builder.Configuration);

builder.Services.ConfigurePersistenceDependencies();

builder.Services.Configure<ApiBehaviorOptions>(options => {

    options.SuppressModelStateInvalidFilter = true;
});


// ValidationFilterAttribute
builder.Services.AddScoped<ValidationFilterAttribute>();

builder.Services.AddScoped<GetAllBannersQueryHandler>();
builder.Services.ConfigureCors();
// LoggerService : Nlog
builder.Services.ConfigureLoggerService();
LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

//AutoMapper

builder.Services.ConfigureAutoMapper();

// MEdiaTr
builder.Services.RegistrationOfMediaTR();

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
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
