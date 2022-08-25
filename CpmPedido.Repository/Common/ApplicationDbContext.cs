using CpmPedido.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CpmPedido.Repository.Common
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cidade> Cidades { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<CategoriaProduto> CategoriaProdutos { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<PromocaoProduto> PromocaoProdutos { get; set; }

        public DbSet<Combo> Combos { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public ApplicationDbContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
