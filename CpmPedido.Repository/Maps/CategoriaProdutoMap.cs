using CpmPedido.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedido.Repository.Maps
{
    public class CategoriaProdutoMap : BaseDomainMap<CategoriaProduto>
    {
        CategoriaProdutoMap() : base("categoriaproduto")
        {
        }

        public override void Configure(EntityTypeBuilder<CategoriaProduto> builder)
        {       
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();
        }
    }
}
