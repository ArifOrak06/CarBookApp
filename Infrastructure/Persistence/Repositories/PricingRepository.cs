using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class PricingRepository : Repository<Pricing>, IPricingRepository
    {
        public PricingRepository(AppDbContext context) : base(context)
        {
        }
    }
}
