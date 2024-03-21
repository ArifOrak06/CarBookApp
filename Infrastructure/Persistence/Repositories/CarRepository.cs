using Application.Repositories;
using Domain.Entities;
using Domain.Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Car>> GetAllActivesAndNonDeletedCarsByBrandIdAsync(int brandId, bool trackChanges) => await GetByFilter(x => x.BrandId.Equals(brandId) && x.IsActive && !x.IsDeleted, trackChanges).Include(x => x.Brand).ToListAsync();
        public async Task<PagedList<Car>> GetAllActivesAndNonDeletedCarsWithBrandAsync(bool trackChanges, CarRequestParameters carRequestParameters)
        {
            var cars =  await GetByFilter(x => x.IsActive && !x.IsDeleted, trackChanges)
                .Include(x => x.Brand)
                .ToListAsync();

            return PagedList<Car>.ToPagedList(cars, carRequestParameters.PageNumber, carRequestParameters.PageSize);

        } 
        public async Task<Car> GetOneCarActiveAndNonDeletedByIdWithBrandAsync(int carId, bool trackChanges) => await GetByFilter(x => x.Id.Equals(carId)&&x.IsActive&&!x.IsDeleted,trackChanges).Include(x => x.Brand).SingleOrDefaultAsync();
    }
}
