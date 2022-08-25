using CpmPedido.Domain.Interfaces;

namespace CpmPedido.Domain.Entities
{
    public class CategoriaProduto : BaseEntity, IActive
    {
        public string Nome { get; set; }

        public bool Ativo { get; set; }
    }
}
