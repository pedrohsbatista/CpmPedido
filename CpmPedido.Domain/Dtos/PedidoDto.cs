namespace CpmPedido.Domain.Dtos
{
    public class PedidoDto
    {
        public long ClienteId { get; set; }

        public List<ProdutoPedidoDto> Produtos { get; set; }
    }
}
