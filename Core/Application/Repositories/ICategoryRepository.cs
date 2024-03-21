using Domain.Entities;
using Domain.Entities.RequestFeatures;

namespace Application.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<PagedList<Category>> GetAllActivesAndNonDeletedCategoriesAsync(bool trackChanges, CategoryRequestParameters categoryRequestParameters);
    }
}
