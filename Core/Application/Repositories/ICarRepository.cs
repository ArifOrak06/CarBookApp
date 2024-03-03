using Domain.Entities;

namespace Application.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<Car> GetOneCarActiveAndNonDeletedByIdWithBrandAsync(int carId,bool trackChanges);
        Task<List<Car>> GetAllActivesAndNonDeletedCarsWithBrandAsync(bool trackChanges);
        Task<List<Car>> GetAllActivesAndNonDeletedCarsByBrandIdAsync(int brandId, bool trackChanges);
        
    }
}
