using CpmPedido.Domain.Entities;
using CpmPedido.Interfaces.Repositories;
using CpmPedido.Repository.Common;

namespace CpmPedido.Repository.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public decimal TicketMaximum()
        {
            return DbContext.Pedidos.Where(x => x.DataInclusao.Date == DateTime.Today).Max(x => (decimal?)x.ValorTotal) ?? 0;
        }

        public dynamic ByCliente()
        {
            var currentDate = new DateTime(2021, 1, 1);
            var start = new DateTime(currentDate.Year, currentDate.Month, 1);
            var end = new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month));

            return DbContext.Pedidos
                          .Where(x => x.DataInclusao.Date >= start && x.DataInclusao.Date <= end)
                          .GroupBy(x => new { x.Cliente.Id, x.Cliente.Nome },
                                   (key, group) => new
                                   {
                                       Cliente = key.Nome,
                                       Pedidos = group.Count(),
                                       Total = group.Sum(y => y.ValorTotal)
                                   })
                          .ToList();

            //return DbContext.Pedidos
            //                .Where(x => x.DataInclusao.Date >= start && x.DataInclusao.Date <= end)
            //                .GroupBy(x => new { x.Cliente.Id, x.Cliente.Nome })
            //                .Select(x => new
            //                {
            //                    Cliente = x.Key.Nome,
            //                    Pedidos = x.Count(),
            //                    Total = x.Sum(y => y.ValorTotal)
            //                })
            //                .ToList();

        }
    }
}
