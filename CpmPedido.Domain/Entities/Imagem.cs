namespace CpmPedido.Domain.Entities
{
    public class Imagem : BaseEntity
    {
        public string Nome { get; set; }

        public string NomeArquivo { get; set; }

        public bool Principal { get; set; }

        public virtual List<Produto> Produtos { get; set; }
    }
}
