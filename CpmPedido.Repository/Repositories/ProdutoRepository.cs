using CpmPedido.Domain.Entities;
using CpmPedido.Interfaces.Repositories;
using CpmPedido.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace CpmPedido.Repository.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {        
        public ProdutoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {            
        }

        public dynamic Get(string order)
        {
            var queryProduto = DbContext.Produtos
                                    .Include(x => x.CategoriaProduto)
                                    .Where(x => x.Ativo);                                    

            Order(ref queryProduto, x => x.Nome, order);

            var queryResult = queryProduto.Select(x => new
            {
                x.Nome,
                x.Preco,
                Categoria = x.CategoriaProduto.Nome,
                Imagens = x.Imagens.Select(y => new
                {
                    y.Id,
                    y.Nome,
                    y.NomeArquivo
                })
            });

            return queryResult.ToList();
        }

        public dynamic Search(string text, int page, string order)
        {
            Expression<Func<Produto, bool>> where = x => x.Ativo
                                    && (x.Descricao.ToUpper().Contains(text.ToUpper())
                                    || x.Nome.ToUpper().Contains(text.ToUpper()));

            var queryProduto = DbContext.Produtos
                                    .Include(x => x.CategoriaProduto)
                                    .Where(where);
                                    
            Order(ref queryProduto, x => x.Nome, order);

            var query = queryProduto.Select(x => new
                         {
                             x.Nome,
                             x.Preco,
                             Categoria = x.CategoriaProduto.Nome,
                             Imagens = x.Imagens.Select(y => new
                             {
                                 y.Id,
                                 y.Nome,
                                 y.NomeArquivo
                             })
                         });

            var produtos = query.Skip(SizePage * (page - 1))
                                 .Take(SizePage)
                                 .ToList();

            var totalProdutos = DbContext.Produtos.Where(where).Count();            

            var totalPages = (int)Math.Ceiling((decimal)totalProdutos / SizePage);

            return new { produtos, totalPages };
        }

        public dynamic Detail(long id)
        {
            return DbContext.Produtos
                            .Include(x => x.CategoriaProduto)
                            .Include(x => x.Imagens)
                            .Where(x => x.Ativo && x.Id == id)
                            .Select(x => new
                            {
                                x.Id,
                                x.Nome,
                                x.Codigo,
                                x.Descricao,
                                x.Preco,                               
                                Categoria = new
                                {
                                    x.CategoriaProduto.Id,
                                    x.CategoriaProduto.Nome
                                },
                                Imagens = x.Imagens.Select(y => new
                                {
                                    y.Id,
                                    y.Nome,
                                    y.NomeArquivo
                                })
                            })
                            .FirstOrDefault();
        }

        public dynamic Imagens(long id)
        {
            return DbContext.Produtos
                .Include(x => x.Imagens)
                .Where(x => x.Ativo && x.Id == id)
                .SelectMany(x => x.Imagens, (produto, imagem) => new
                {
                    ProdutoId = produto.Id,
                    imagem.Id,
                    imagem.Nome,
                    imagem.NomeArquivo
                });
        }
    }
}
