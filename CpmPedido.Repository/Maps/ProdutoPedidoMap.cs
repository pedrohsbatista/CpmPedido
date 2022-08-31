using CpmPedido.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedido.Repository.Maps
{
    public class ProdutoPedidoMap : BaseDomainMap<ProdutoPedido>
    {
        ProdutoPedidoMap() : base("produtopedido")
        {
        }

        public override void Configure(EntityTypeBuilder<ProdutoPedido> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Quantidade).HasColumnName("quantidade").HasPrecision(2).IsRequired();
            builder.Property(x => x.Preco).HasColumnName("preco").HasPrecision(17, 2).IsRequired();

            builder.Property(x => x.PedidoId).HasColumnName("pedidoid").IsRequired();
            builder.HasOne(x => x.Pedido).WithMany(x => x.Produtos).HasForeignKey(x => x.PedidoId);

            builder.Property(x => x.ProdutoId).HasColumnName("produtoid").IsRequired();
            builder.HasOne(x => x.Produto).WithMany().HasForeignKey(x => x.ProdutoId);
        }
    }
}
