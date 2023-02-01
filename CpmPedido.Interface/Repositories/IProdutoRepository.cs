using CpmPedido.Domain.Entities;

namespace CpmPedido.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        List<Produto> Get();

        dynamic Search(string text, int page);

        Produto Detail(long id);
    }
}
