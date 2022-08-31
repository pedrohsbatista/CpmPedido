using CpmPedido.Domain.Interfaces;

namespace CpmPedido.Domain.Entities
{
    public class Produto : BaseEntity, IActive
    {
        public string Nome { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public long CategoriaId { get; set; }

        public virtual CategoriaProduto CategoriaProduto { get; set; }

        public virtual List<Imagem> Imagens { get; set; }

        public virtual List<PromocaoProduto> Promocoes { get; set; }

        public virtual List<Combo> Combos { get; set; }

        public bool Ativo { get; set; }
    }
}
