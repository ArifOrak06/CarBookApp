using Domain.Entities;
using Domain.Entities.RequestFeatures;

namespace Application.Repositories
{
    public interface IPricingRepository : IRepository<Pricing>
    {
        Task<PagedList<Pricing>> GetAllActivesAndNonDeletedPricingsAsync(bool trackChanges, PricingRequestParameters pricingRequestParameters);
    }
}
