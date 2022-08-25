namespace CpmPedido.Domain.Entities
{
    public class ProdutoPedido : BaseEntity
    {
        public int Quantidade { get; set; }

        public decimal Preco { get; set; }

        public long ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        public long PedidoId { get; set; }

        public virtual Pedido Pedido { get; set; }
    }
}
