using CpmPedido.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedido.Repository.Maps
{
    public class PedidoMap : BaseDomainMap<Pedido>
    {
        public PedidoMap() : base("pedido")
        {
        }

        public override void Configure(EntityTypeBuilder<Pedido> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Numero).HasColumnName("numero").HasMaxLength(10).IsRequired();
            builder.Property(x => x.ValorTotal).HasColumnName("valortotal").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.Entrega).HasColumnName("entrega");

            builder.Property(x => x.ClienteId).HasColumnName("clienteid").IsRequired();
            builder.HasOne(x => x.Cliente).WithMany(x => x.Pedidos).HasForeignKey(x => x.ClienteId);
        }
    }
}
