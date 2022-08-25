namespace CpmPedido.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public string Numero { get; set; }

        public decimal ValorTotal { get; set; }

        public TimeSpan Entrega { get; set; }

        public long ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual List<ProdutoPedido> Produtos { get; set; }
    }
}
