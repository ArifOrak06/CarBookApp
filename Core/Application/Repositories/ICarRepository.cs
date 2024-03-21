using Domain.Entities;
using Domain.Entities.RequestFeatures;

namespace Application.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<Car> GetOneCarActiveAndNonDeletedByIdWithBrandAsync(int carId,bool trackChanges);
        Task<PagedList<Car>> GetAllActivesAndNonDeletedCarsWithBrandAsync(bool trackChanges, CarRequestParameters carRequestParameters);
        Task<List<Car>> GetAllActivesAndNonDeletedCarsByBrandIdAsync(int brandId, bool trackChanges);
        
    }
}
