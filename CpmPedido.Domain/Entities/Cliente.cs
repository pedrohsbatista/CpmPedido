using CpmPedido.Domain.Interfaces;

namespace CpmPedido.Domain.Entities
{
    public class Cliente : BaseEntity, IActive
    {
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public long EnderecoId { get; set; }

        public virtual Endereco Endereco { get; set; }

        public bool Ativo { get; set; }
    }
}
