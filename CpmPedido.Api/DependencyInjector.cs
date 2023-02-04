using CpmPedido.Interface.Repositories;
using CpmPedido.Interfaces.Repositories;
using CpmPedido.Repository.Repositories;

namespace CpmPedido.Api
{
    public class DependencyInjector
    {
        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependence(serviceProvider);
        }

        private static void RepositoryDependence(IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<IProdutoRepository, ProdutoRepository>();
            serviceProvider.AddScoped<IPedidoRepository, PedidoRepository>();
            serviceProvider.AddScoped<ICidadeRepository, CidadeRepository>();
        }
    }
}
