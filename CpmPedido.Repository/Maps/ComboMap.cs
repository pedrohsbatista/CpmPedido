using CpmPedido.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedido.Repository.Maps
{
    public class ComboMap : BaseDomainMap<Combo>
    {
        ComboMap() : base("combo")
        {
        }

        public override void Configure(EntityTypeBuilder<Combo> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();

            builder.Property(x => x.ImagemId).HasColumnName("imagemid").IsRequired();
            builder.HasOne(x => x.Imagem).WithMany().HasForeignKey(x => x.ImagemId);

            builder
                .HasMany(x => x.Produtos)
                .WithMany(x => x.Combos)
                .UsingEntity<ProdutoCombo>(
                    x => x.HasOne(x => x.Produto).WithMany().HasForeignKey(x => x.ProdutoId),
                    x => x.HasOne(x => x.Combo).WithMany().HasForeignKey(x => x.ComboId),
                    x =>
                    {
                        x.ToTable("produtocombo");

                        x.HasKey(x => new { x.ProdutoId, x.ComboId });

                        x.Property(x => x.ProdutoId).HasColumnName("produtoid").IsRequired();
                        x.Property(x => x.ComboId).HasColumnName("comboid").IsRequired();
                    }
                );
        }
    }
}
