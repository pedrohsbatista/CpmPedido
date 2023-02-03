namespace CpmPedido.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        decimal TicketMaximum();

        dynamic ByCliente();
    }
}
