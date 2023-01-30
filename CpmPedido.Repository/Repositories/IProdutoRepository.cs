using CpmPedido.Domain.Entities;

namespace CpmPedido.Repository.Repositories
{
    public interface IProdutoRepository
    {
        List<Produto> Get();
    }
}
