using valu.BLL.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace valu.BLL.InterFaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetSingleAsync(ISpecification<T> spec);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetListAsync(ISpecification<T> spec);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate = null);
        Task<List<T>> GetWithIncludeAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);

        Task<int> CountAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        Task AttachAsync(T entity);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(List<T> entities);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
