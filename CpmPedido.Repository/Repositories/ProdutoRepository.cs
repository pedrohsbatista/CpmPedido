using CpmPedido.Domain.Entities;
using CpmPedido.Repository.Common;
using Microsoft.EntityFrameworkCore;
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
            return DbContext.Produtos.Include(x => x.CategoriaProduto)
                                    .Where(x => x.Ativo)
                                    .OrderBy(x => x.Nome)
                                    .ToList();
        }

        public List<Produto> Search(string text, int page)
        {
            return DbContext.Produtos.Include(x => x.CategoriaProduto)
                                    .Where(x => x.Ativo
                                    && (x.Descricao.ToUpper().Contains(text.ToUpper()) 
                                    || x.Nome.ToUpper().Contains(text.ToUpper())))
                                    .OrderBy(x => x.Nome)
                                    .Skip(SizePage * (page - 1))
                                    .Take(SizePage)                                    
                                    .ToList();
        }

        public Produto Detail(long id)
        {
            return DbContext.Produtos
                            .Include(x => x.CategoriaProduto)
                            .Include(x => x.Imagens)
                            .Where(x => x.Ativo && x.Id == id)
                            .FirstOrDefault();
        }
    }
}
