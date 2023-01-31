using CpmPedido.Domain.Entities;

namespace CpmPedido.Repository.Repositories
{
    public interface IProdutoRepository
    {
        List<Produto> Get();

        List<Produto> Search(string text);
    }
}
