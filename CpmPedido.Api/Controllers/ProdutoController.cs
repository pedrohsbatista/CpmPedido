using CpmPedido.Domain.Entities;
using CpmPedido.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CpmPedido.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]    
    public class ProdutoController : AppBaseController
    {
        public ProdutoController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            var repoProduto = (IProdutoRepository)ServiceProvider.GetService(typeof(IProdutoRepository));
            return repoProduto.Get();
        }

        [HttpGet]
        [Route("search/{text}/{page?}")]
        public IEnumerable<Produto> GetSearch(string text, int page = 1)
        {
            var repoProduto = (IProdutoRepository)ServiceProvider.GetService(typeof(IProdutoRepository));
            return repoProduto.Search(text, page);
        }

        [HttpGet]
        [Route("{id}")]
        public Produto GetDetail(long id)
        {
            var repoProduto = (IProdutoRepository)ServiceProvider.GetService(typeof(IProdutoRepository));
            return repoProduto.Detail(id);
        }
    }
}
