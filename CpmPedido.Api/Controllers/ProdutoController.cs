using CpmPedido.Domain.Entities;
using CpmPedido.Interfaces.Repositories;
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
        public dynamic Get()
        {
            var repoProduto = (IProdutoRepository)ServiceProvider.GetService(typeof(IProdutoRepository));
            return repoProduto.Get();
        }

        [HttpGet]
        [Route("search/{text}/{page?}")]
        public dynamic GetSearch(string text, int page = 1)
        {
            var repoProduto = (IProdutoRepository)ServiceProvider.GetService(typeof(IProdutoRepository));
            return repoProduto.Search(text, page);
        }

        [HttpGet]
        [Route("{id}")]
        public dynamic GetDetail(long id)
        {
            var repoProduto = (IProdutoRepository)ServiceProvider.GetService(typeof(IProdutoRepository));
            return repoProduto.Detail(id);
        }

        [HttpGet]
        [Route("images/{id}")]
        public dynamic GetImagens(long id)
        {
            var repoProduto = (IProdutoRepository)ServiceProvider.GetService(typeof(IProdutoRepository));
            return repoProduto.Imagens(id);
        }        
    }
}
