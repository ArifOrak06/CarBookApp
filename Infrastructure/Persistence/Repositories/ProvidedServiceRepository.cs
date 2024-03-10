using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ProvidedServiceRepository : Repository<ProvidedService>, IProvidedServiceRepository
    {
        public ProvidedServiceRepository(AppDbContext context) : base(context)
        {
           
        }

    }
}
