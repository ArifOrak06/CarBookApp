using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Brand>> GetAllActiveAndNonDeletedBrandsWithCarsAsync(bool trackChanges) => await GetByFilter(x => x.IsActive, trackChanges).Include(x => x.Cars).ToListAsync();
        public async Task<Brand> GetOneActiveAndNonDeletedBrandByIdWithCarsAsync(int brandId, bool trackChanges) => await GetByFilter(x => x.Id.Equals(brandId) && x.IsActive, trackChanges).Include(x => x.Cars).SingleOrDefaultAsync();
    }
}
