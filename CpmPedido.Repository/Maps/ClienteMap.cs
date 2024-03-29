﻿using CpmPedido.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedido.Repository.Maps
{
    public class ClienteMap : BaseDomainMap<Cliente>
    {
        public ClienteMap() : base("cliente")
        {
        }

        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Cpf).HasColumnName("cpf").HasMaxLength(11).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").IsRequired();

            builder.Property(x => x.EnderecoId).HasColumnName("enderecoid").IsRequired();
        }
    }
}
