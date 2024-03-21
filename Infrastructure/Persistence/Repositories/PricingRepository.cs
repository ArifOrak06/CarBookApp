using Application.Repositories;
using Domain.Entities;
using Domain.Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class PricingRepository : Repository<Pricing>, IPricingRepository
    {
        public PricingRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PagedList<Pricing>> GetAllActivesAndNonDeletedPricingsAsync(bool trackChanges, PricingRequestParameters pricingRequestParameters)
        {
            List<Pricing>? pricings = await this.GetByFilter(x => x.IsActive && !x.IsDeleted, trackChanges).ToListAsync();
            return PagedList<Pricing>.ToPagedList(pricings, pricingRequestParameters.PageNumber, pricingRequestParameters.PageSize);

        }
    }
}
