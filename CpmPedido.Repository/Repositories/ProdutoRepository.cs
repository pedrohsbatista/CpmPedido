using CpmPedido.Domain.Entities;
using CpmPedido.Interfaces.Repositories;
using CpmPedido.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

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

        public dynamic Search(string text, int page)
        {
            Expression<Func<Produto, bool>> where = x => x.Ativo
                                    && (x.Descricao.ToUpper().Contains(text.ToUpper())
                                    || x.Nome.ToUpper().Contains(text.ToUpper()));

            var produtos = DbContext.Produtos.Include(x => x.CategoriaProduto)
                                    .Where(where)
                                    .OrderBy(x => x.Nome)
                                    .Skip(SizePage * (page - 1))
                                    .Take(SizePage)                                    
                                    .ToList();

            var totalProdutos = DbContext.Produtos.Where(where).Count();

            var totalPages = totalProdutos / SizePage + 1;          

            return new { produtos, totalPages };
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
