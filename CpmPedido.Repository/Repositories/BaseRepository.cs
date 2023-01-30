using CpmPedido.Repository.Common;

namespace CpmPedido.Repository.Repositories
{
    public class BaseRepository
    {
        protected readonly ApplicationDbContext DbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
