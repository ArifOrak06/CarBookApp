using Domain.Entities;

namespace Application.Repositories
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task<IEnumerable<Brand>> GetAllActiveAndNonDeletedBrandsWithCarsAsync(bool trackChanges);
        Task<Brand> GetOneActiveAndNonDeletedBrandByIdWithCarsAsync(int brandId,bool trackChanges);
    }
}
