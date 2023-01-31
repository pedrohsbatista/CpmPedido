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
            return DbContext.Produtos.Where(x => x.Ativo).OrderBy(x => x.Nome).ToList();
        }

        public List<Produto> Search(string text)
        {
            return DbContext.Produtos.Where(x => x.Ativo
                                            && (x.Descricao.ToUpper().Contains(text.ToUpper()) 
                                            || x.Nome.ToUpper().Contains(text.ToUpper())))
                                            .OrderBy(x => x.Nome)
                                            .ToList();
        }
    }
}
