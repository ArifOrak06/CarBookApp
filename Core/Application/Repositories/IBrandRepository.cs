using Domain.Entities;
using Domain.Entities.RequestFeatures;

namespace Application.Repositories
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task<PagedList<Brand>> GetAllActiveAndNonDeletedBrandsWithCarsAsync(bool trackChanges, BrandRequestParameters brandRequestParameters);
        Task<Brand> GetOneActiveAndNonDeletedBrandByIdWithCarsAsync(int brandId,bool trackChanges);
    }
}
