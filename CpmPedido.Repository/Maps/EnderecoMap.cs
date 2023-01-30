using CpmPedido.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedido.Repository.Maps
{
    public class EnderecoMap : BaseDomainMap<Endereco>
    {
        public EnderecoMap() : base("endereco")
        {
        }

        public override void Configure(EntityTypeBuilder<Endereco> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.TipoEndereco).HasColumnName("tipoendereco").IsRequired();
            builder.Property(x => x.Logradouro).HasColumnName("logradouro").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Bairro).HasColumnName("bairro").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Numero).HasColumnName("numero").HasMaxLength(10);
            builder.Property(x => x.Complemento).HasColumnName("complemento").HasMaxLength(50);
            builder.Property(x => x.Cep).HasColumnName("cep").HasMaxLength(8);

            builder.HasOne(x => x.Cliente).WithOne(x => x.Endereco).HasForeignKey<Cliente>(x => x.EnderecoId);

            builder.Property(x => x.CidadeId).HasColumnName("cidadeid").IsRequired();
            builder.HasOne(x => x.Cidade).WithMany().HasForeignKey(x => x.CidadeId);
        }
    }
}
