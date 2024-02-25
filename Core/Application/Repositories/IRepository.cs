using System.Linq.Expressions;

namespace Application.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(bool trackChanges);
        IQueryable<T> GetByFilter(Expression<Func<T, bool>> expression,bool trackChanges);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
