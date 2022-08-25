using CpmPedido.Domain.Enums;

namespace CpmPedido.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public TipoEndereco TipoEndereco { get; set; }

        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Cep { get; set; }

        public long CidadeId { get; set; }

        public virtual Cidade Cidade { get; set; }
    }
}
