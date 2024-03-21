using Application.Repositories;
using Domain.Entities;
using Domain.Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PagedList<Brand>> GetAllActiveAndNonDeletedBrandsWithCarsAsync(bool trackChanges, BrandRequestParameters brandRequestParameters)
        {
            List<Brand> brands = await GetByFilter(x => x.IsActive&&!x.IsDeleted, trackChanges)
                .Include(x => x.Cars)
                .ToListAsync();
            return PagedList<Brand>.ToPagedList(brands, brandRequestParameters.PageNumber, brandRequestParameters.PageSize);
        }
        public async Task<Brand> GetOneActiveAndNonDeletedBrandByIdWithCarsAsync(int brandId, bool trackChanges) => await GetByFilter(x => x.Id.Equals(brandId) && x.IsActive, trackChanges).Include(x => x.Cars).SingleOrDefaultAsync();
    }
}
