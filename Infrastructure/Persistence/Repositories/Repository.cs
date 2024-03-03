using Application.Repositories;
using Domain.Entities.Abstracts;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class,IEntity,new()
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression) => await _context.Set<T>().AnyAsync(expression);

        public async Task<T> CreateAsync(T entity)
        {

            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Delete(T entity) => _context.Set<T>().Remove(entity);
        public async Task<IEnumerable<T>> GetAllAsync(bool trackChanges) => !trackChanges ? await _context.Set<T>().AsNoTracking().ToListAsync() : await _context.Set<T>().ToListAsync();

        public IQueryable<T> GetByFilter(Expression<Func<T, bool>> expression, bool trackChanges) => !trackChanges ? _context.Set<T>().Where(expression).AsNoTracking() : _context.Set<T>().Where(expression);

        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}
