using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace valu.BLL.Specification
{
    public class Specification<T> : ISpecification<T>
    {
        public Specification() { }
        public Specification(Expression<Func<T, bool>> wherePredicate)
        {
            WherePredicate = wherePredicate;
        }

        public Expression<Func<T, bool>> WherePredicate { get; private set; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public List<string> ThenIncludes { get; } = new List<string>();
        public Expression<Func<T, object>> OrderByPredicate { get; private set; }
        public Expression<Func<T, object>> OrderByDescPredicate { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPaginationEnabled { get; set; } = false;
        public void ApplyPagination(int pageIndex, int pageSize)
        {
            Skip = pageSize * (pageIndex - 1);
            Take = pageSize;
            IsPaginationEnabled = true;
        }
        public void Where(Expression<Func<T, bool>> predicate)
        {
            WherePredicate = predicate;
        }
        public void OrderBy(Expression<Func<T, object>> predicate)
        {
            OrderByPredicate = predicate;
        }
        public void OrderByDesc(Expression<Func<T, object>> predicate)
        {
            OrderByDescPredicate = predicate;

        }
    }
}
