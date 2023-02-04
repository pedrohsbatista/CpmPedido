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
        public dynamic Get([FromQuery] string? order)
        {
            var repoProduto = GetService<IProdutoRepository>();
            return repoProduto.Get(order);
        }

        [HttpGet]
        [Route("search/{text}/{page?}")]
        public dynamic GetSearch(string text, int page = 1, [FromQuery] string? order = null)
        {
            var repoProduto = GetService<IProdutoRepository>();
            return repoProduto.Search(text, page, order);
        }

        [HttpGet]
        [Route("{id}")]
        public dynamic GetDetail(long id)
        {
            var repoProduto = GetService<IProdutoRepository>();
            return repoProduto.Detail(id);
        }

        [HttpGet]
        [Route("images/{id}")]
        public dynamic GetImages(long id)
        {
            var repoProduto = GetService<IProdutoRepository>();
            return repoProduto.Imagens(id);
        }        
    }
}
