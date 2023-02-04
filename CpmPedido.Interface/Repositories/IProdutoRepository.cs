namespace CpmPedido.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        dynamic Get(string order);

        dynamic Search(string text, int page, string order);

        dynamic Detail(long id);

        dynamic Imagens(long id);
    }
}
