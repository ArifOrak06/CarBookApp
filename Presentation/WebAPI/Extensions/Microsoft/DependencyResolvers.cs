using Application.Features.CQRS.Handlers.AboutHandlers;
using Application.Features.CQRS.Handlers.BannerHandlers;
using Application.Features.CQRS.Handlers.BrandHandlers;
using Application.Features.CQRS.Handlers.CarHandlers;
using Application.Features.CQRS.Handlers.CategoryHandlers;
using Application.Features.CQRS.Handlers.ContactHandlers;
using Application.Features.CQRS.Handlers.FeatureHandlers;
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
        
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BannerProfile));
                
        }
        public static void RegistrationOfMediaTR(this IServiceCollection services) => services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CarProfile).Assembly));
        public static void  ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().WithExposedHeaders("X-Pagination");
                });
            });
        }
    }
}
