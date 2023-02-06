using CpmPedido.Domain.Dtos;

namespace CpmPedido.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        decimal TicketMaximum();

        dynamic ByCliente();

        string Insert(PedidoDto pedidoDto);
    }
}
