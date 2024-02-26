using Application.Features.CQRS.Handlers.AboutHandlers;
using Application.Features.CQRS.Handlers.BannerHandlers;
using Application.Services.Logging;
using Application.Utilities.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Reflection;

namespace WebAPI.Extensions.Microsoft
{
    public static class DependencyResolvers
    {
        public static void ConfigureDbContext(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"), opt =>
                {
                    opt.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
                });
            });
        }
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, LoggerService>();
        }
        public static void AddCQRSServices(this IServiceCollection services)
        {
            services.AddScoped<CreateOneAboutCommandHandler>();
            services.AddScoped<RemoveOneAboutCommandHandler>();
            services.AddScoped<UpdateOneAboutCommandHandler>();
            services.AddScoped<GetOneAboutByIdQueryHandler>();
            services.AddScoped<GetAllAboutsQueryHandler>();

      
            services.AddScoped<GetOneBannerByIdQueryHandler>();
            services.AddScoped<CreateOneBannerCommandHandler>();
            services.AddScoped<UpdateOneBannerCommandHandler>();
            services.AddScoped<RemoveOneBannerCommandHandler>();

        }
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BannerProfile));
                
        }

    }
}
