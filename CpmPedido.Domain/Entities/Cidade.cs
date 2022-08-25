using CpmPedido.Domain.Interfaces;

namespace CpmPedido.Domain.Entities
{
    public class Cidade : BaseEntity, IActive
    {
        public string Nome { get; set; }

        public string Uf { get; set; }

        public bool Ativo { get; set; }
    }
}
