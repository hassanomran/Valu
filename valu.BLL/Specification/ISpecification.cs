using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace valu.BLL.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> WherePredicate { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> ThenIncludes { get; }
        Expression<Func<T, object>> OrderByPredicate { get; }
        Expression<Func<T, object>> OrderByDescPredicate { get; }
        int Take { get; }
        int Skip { get; }
        bool IsPaginationEnabled { get; }
        void ApplyPagination(int pageIndex, int pageSize);
        void Where(Expression<Func<T, bool>> predicate);
        void OrderBy(Expression<Func<T, object>> predicate);
        void OrderByDesc(Expression<Func<T, object>> predicate);
    }
}
