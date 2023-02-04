using CpmPedido.Domain.Dtos;

namespace CpmPedido.Interface.Repositories
{
    public interface ICidadeRepository
    {
        dynamic Get();
        long Insert(CidadeDto cidadeDto);
    }
}
