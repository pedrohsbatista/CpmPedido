namespace CpmPedido.Domain.Entities
{
    public class ImagemProduto
    {
        public long ImagemId { get; set; }
        public virtual Imagem Imagem { get; set; }
        public long ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
