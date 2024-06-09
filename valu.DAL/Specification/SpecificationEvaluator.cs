using valu.BLL.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valu.DAL.Specification
{
    /// <summary>
    /// this genaric class is used to build dynamic query of an entity.
    /// </summary>
    /// <typeparam name="TEntity">Entity Type</typeparam>
    public class SpecificationEvaluator<TEntity> where TEntity : class
    {
        /// <summary>
        /// Build dynamic query for an entity using Specification Pattern.
        /// </summary>
        /// <param name="inputQuery">Query</param>
        /// <param name="spec">Entity Query Specification</param>
        /// <returns>Iqueryable of Entity</returns>
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if (spec.WherePredicate != null)
            {
                query = query.Where(spec.WherePredicate);
            }
            if (spec.OrderByPredicate != null)
            {
                query = query.OrderBy(spec.OrderByPredicate);
            }
            if (spec.OrderByDescPredicate != null)
            {
                query = query.OrderByDescending(spec.OrderByDescPredicate);
            }
            if (spec.IsPaginationEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }
            if (spec.Includes.Count > 0)
            {
                query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }
    }
}
