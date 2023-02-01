using CpmPedido.Interfaces.Repositories;
using CpmPedido.Repository.Common;

namespace CpmPedido.Repository.Repositories
{
    public class PedidoRepository : BaseRepository, IPedidoRepository
    {
        public PedidoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public decimal TicketMaximum()
        {
           return DbContext.Pedidos.Where(x => x.DataInclusao.Date == DateTime.Today).Max(x => (decimal?) x.ValorTotal) ?? 0;            
        }
    }
}
