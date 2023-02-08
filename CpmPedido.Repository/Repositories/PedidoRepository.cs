using CpmPedido.Domain.Dtos;
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

        public string Insert(PedidoDto pedidoDto)
        {
            using var transaction = DbContext.Database.BeginTransaction();

            try
            {
                var pedido = new Pedido
                {
                    Numero = GetNextNumeroPedido(),
                    ClienteId = pedidoDto.ClienteId,
                    DataInclusao = DateTime.Now,
                    Produtos = new List<ProdutoPedido>()
                };

                decimal valorTotal = 0;

                foreach (var produtoPedidoDto in pedidoDto.Produtos)
                {
                    var valorUnitario = DbContext.Produtos
                                        .Where(x => x.Id == produtoPedidoDto.ProdutoId)
                                        .Select(x => x.Preco)
                                        .FirstOrDefault();                                      

                    var produtoPedido = new ProdutoPedido
                    {
                        ProdutoId = produtoPedidoDto.ProdutoId,
                        Quantidade = produtoPedidoDto.Quantidade,
                        Preco = valorUnitario
                    };

                    pedido.Produtos.Add(produtoPedido);

                    valorTotal += produtoPedidoDto.Quantidade * valorUnitario;
                }

                pedido.ValorTotal = valorTotal;

                DbContext.Pedidos.Add(pedido);

                DbContext.SaveChanges();

                transaction.Commit();

                return pedido.Numero;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        private string GetNextNumeroPedido()
        {
            var lastNumero = DbContext.Pedidos.Max(x => x.Numero);

            var nextNumero = !string.IsNullOrEmpty(lastNumero) ? Convert.ToInt32(lastNumero) + 1 : 1;

            return nextNumero.ToString("00000");
        }
    }
}
