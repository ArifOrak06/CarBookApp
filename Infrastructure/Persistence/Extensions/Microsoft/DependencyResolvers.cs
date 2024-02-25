using Application.Repositories;
using Application.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Persistence.UnitOfWorks;



namespace Persistence.Extensions.Microsoft
{
    public static class DependencyResolvers
    {

        public static void ConfigurePersistenceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
