using valu.DAL.Database;
using Microsoft.EntityFrameworkCore;
using valu.BLL.Specification;
using valu.BLL.InterFaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using valu.DAL.Specification;

namespace valu.DAL.Repositories
{
    public class BaseRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ContextDB _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(ContextDB context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task AddRangeAsync(List<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task UpdateRangeAsync(List<T> entities)
        {
            _context.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }
        public async Task AttachAsync(T entity)
        {
            _context.Set<T>().Attach(entity);
            await _context.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Get a list of entites from database based on specified Query using Specification Pattern.
        /// </summary>
        /// <param name="spec">Entity Query Specification.</param>
        /// <returns>List Of Entities.</returns>
        public async Task<IReadOnlyList<T>> GetListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _context.Set<T>().ToListAsync();
            }
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
        /// <summary>
        /// Get an entity from database based on specified Query using Specification Pattern.
        /// </summary>
        /// <param name="spec">Entity Query Specification.</param>
        /// <returns>Entity</returns>
        public async Task<T> GetSingleAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
        /// <summary>
        /// Get the count of the Result based on specified Query using Specification Pattern.
        /// </summary>
        /// <param name="spec">Entity Query Specification.<</param>
        /// <returns>Intger of the Count.</returns>
        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }
        /// <summary>
        /// Applay Query Specification on an entity to build the query.
        /// </summary>
        /// <param name="spec">Query Specification</param>
        /// <returns>IQueryable of Entity.</returns>
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }

        public async Task<List<T>> GetWithIncludeAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.ToListAsync();
        }
    }
}
