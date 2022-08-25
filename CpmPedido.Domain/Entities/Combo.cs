using CpmPedido.Domain.Interfaces;

namespace CpmPedido.Domain.Entities
{
    public class Combo : BaseEntity, IActive
    {
        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public long ImagemId { get; set; }

        public virtual Imagem Imagem { get; set; }

        public virtual List<Produto> Produtos { get; set; }

        public bool Ativo { get; set; }
    }
}
