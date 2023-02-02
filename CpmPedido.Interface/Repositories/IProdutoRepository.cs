using CpmPedido.Domain.Entities;

namespace CpmPedido.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        dynamic Get();

        dynamic Search(string text, int page);

        dynamic Detail(long id);

        dynamic Imagens(long id);
    }
}
