using CpmPedido.Domain.Interfaces;

namespace CpmPedido.Domain.Entities
{
    public class PromocaoProduto : BaseEntity, IActive
    {
        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public long ImagemId { get; set; }

        public virtual Imagem Imagem { get; set; }

        public long ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }

        public bool Ativo { get; set; }
    }
}
