using Application.Repositories;
using Domain.Entities;
using Domain.Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PagedList<Category>> GetAllActivesAndNonDeletedCategoriesAsync(bool trackChanges, CategoryRequestParameters categoryRequestParameters)
        {
            List<Category>? categories = await this.GetByFilter(x => x.IsActive && !x.IsDeleted, trackChanges).ToListAsync();
            return PagedList<Category>.ToPagedList(categories, categoryRequestParameters.PageNumber,categoryRequestParameters.PageSize);
        }
    }
}
