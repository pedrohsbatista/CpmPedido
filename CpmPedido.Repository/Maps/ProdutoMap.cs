using CpmPedido.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedido.Repository.Maps
{
    public class ProdutoMap : BaseDomainMap<Produto>
    {
        public ProdutoMap() : base("produto")
        {
        }

        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Codigo).HasColumnName("codigo").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Descricao).HasColumnName("descricao").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();

            builder.Property(x => x.CategoriaId).HasColumnName("categoriaid").IsRequired();
            builder.HasOne(x => x.CategoriaProduto).WithMany(x => x.Produtos).HasForeignKey(x => x.CategoriaId);

            builder
                .HasMany(x => x.Imagens)
                .WithMany(x => x.Produtos)
                .UsingEntity<ImagemProduto>(
                  x => x.HasOne(x => x.Imagem).WithMany().HasForeignKey(x => x.ImagemId),
                  x => x.HasOne(x => x.Produto).WithMany().HasForeignKey(x => x.ProdutoId),
                  x =>
                  {
                      x.ToTable("imagemproduto");

                      x.HasKey(x => new { x.ProdutoId, x.ImagemId });

                      x.Property(x => x.ImagemId).HasColumnName("imagemid").IsRequired();
                      x.Property(x => x.ProdutoId).HasColumnName("produtoid").IsRequired();                      
                  }
                );
        }
    }
}
