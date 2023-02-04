using CpmPedido.Repository.Common;
using System.Linq.Expressions;

namespace CpmPedido.Repository.Repositories
{
    public class BaseRepository<T>
    {
        protected readonly ApplicationDbContext DbContext;

        protected readonly int SizePage = 5;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected IQueryable<T> Order(IQueryable<T> query, Expression<Func<T, string>> orderExpression, string order)
        {
            if (!string.IsNullOrEmpty(order) && order.ToUpper().Equals("DESC"))
                return query.OrderByDescending(orderExpression);
            else
                return query.OrderBy(orderExpression);
        }
    }
}
