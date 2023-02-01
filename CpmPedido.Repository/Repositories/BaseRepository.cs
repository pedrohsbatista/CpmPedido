using CpmPedido.Repository.Common;

namespace CpmPedido.Repository.Repositories
{
    public class BaseRepository
    {
        protected readonly ApplicationDbContext DbContext;

        protected readonly int SizePage = 5;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
