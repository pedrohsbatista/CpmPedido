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

        protected void Order(ref IQueryable<T> query, Expression<Func<T, string>> orderExpression, string order)
        {
            if (!string.IsNullOrEmpty(order) && order.ToUpper().Equals("DESC"))
                query = query.OrderByDescending(orderExpression);
            else
                query = query.OrderBy(orderExpression);
        }
    }
}
