namespace CpmPedido.Domain.Entities
{
    public class ProdutoCombo
    {
        public long ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        public long ComboId { get; set; }

        public virtual Combo Combo { get; set; }
    }
}
