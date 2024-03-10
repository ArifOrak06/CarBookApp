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
        public static void AddCQRSServices(this IServiceCollection services)
        {
            //About
            services.AddScoped<CreateOneAboutCommandHandler>();
            services.AddScoped<RemoveOneAboutCommandHandler>();
            services.AddScoped<UpdateOneAboutCommandHandler>();
            services.AddScoped<GetOneAboutByIdQueryHandler>();
            services.AddScoped<GetAllAboutsQueryHandler>();

            //Banner
            services.AddScoped<GetOneBannerByIdQueryHandler>();
            services.AddScoped<CreateOneBannerCommandHandler>();
            services.AddScoped<UpdateOneBannerCommandHandler>();
            services.AddScoped<RemoveOneBannerCommandHandler>();

            //Brand
            services.AddScoped<GetOneBrandByIdQueryHandler>();
            services.AddScoped<GetAllBrandsQueryHandler>();
            services.AddScoped<CreateOneBrandCommandHandler>();
            services.AddScoped<UpdateOneBrandCommandHandler>();
            services.AddScoped<RemoveOneBrandCommandHandler>();
            services.AddScoped<GetOneBrandByIdWithCarsQueryHandler>();
            //Car
            services.AddScoped<GetOneCarByIdQueryHandler>();
            services.AddScoped<GetAllCarsQueryHandler>();
            services.AddScoped<CreateOneCarCommandHandler>();
            services.AddScoped<UpdateOneCarCommandHandler>();
            services.AddScoped<RemoveOneCarCommandHandler>();
            services.AddScoped<GetOneCarByIdWithBrandQueryHandler>();
            services.AddScoped<GetAllCarsWithBrandsQueryHandler>();
            // Category
            services.AddScoped<GetOneCategoryByIdQueryHandler>();
            services.AddScoped<GetAllCategoriesQueryHandler>();
            services.AddScoped<CreateOneCategoryCommandHandler>();
            services.AddScoped<UpdateOneCategoryCommandHandler>();
            services.AddScoped<RemoveOneCategoryCommandHandler>();
            // Contact
            services.AddScoped<GetOneContactByIdQueryHandler>();
            services.AddScoped<GetAllContactsQueryHandler>();
            services.AddScoped<CreateOneContactCommandHandler>();
            services.AddScoped<UpdateOneContactCommandHandler>();
            services.AddScoped<RemoveOneContactCommandHandler>();

            // feature
            //services.AddScoped<GetOneFeatureByIdQueryHandler>();
            //services.AddScoped<GetAllFeaturesQueryHandler>();
            //services.AddScoped<CreateOneFeatureCommandHandler>();
            //services.AddScoped<UpdateOneFeatureCommandHandler>();
            //services.AddScoped<RemoveOneFeatureCommandHandler>();

           


        

        }
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BannerProfile));
                
        }
        public static void RegistrationOfMediaTR(this IServiceCollection services) => services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CarProfile).Assembly));
    }
}
