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
    }
}
