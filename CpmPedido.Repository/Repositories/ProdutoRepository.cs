using CpmPedido.Domain.Entities;
using CpmPedido.Repository.Common;
using System.Linq;

namespace CpmPedido.Repository.Repositories
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {        
        public ProdutoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {            
        }

        public List<Produto> Get()
        {
            return DbContext.Produtos.ToList();
        }
    }
}
