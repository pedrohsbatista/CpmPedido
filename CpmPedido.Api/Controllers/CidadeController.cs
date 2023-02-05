using CpmPedido.Domain.Dtos;
using CpmPedido.Domain.Entities;
using CpmPedido.Interface.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CpmPedido.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CidadeController : AppBaseController
    {
        public CidadeController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet]
        public dynamic Get()
        {
            var repoCidade = GetService<ICidadeRepository>();
            return repoCidade.Get();
        }

        [HttpPost]
        public long Post(CidadeDto cidadeDto)
        {
            var repoCidade = GetService<ICidadeRepository>();
            return repoCidade.Insert(cidadeDto);
        }

        [HttpPut]
        public long Put(CidadeDto cidadeDto)
        {
            var repoCidade = GetService<ICidadeRepository>();
            return repoCidade.Update(cidadeDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public bool Delete(long id)
        {
            var repoCidade = GetService<ICidadeRepository>();
            return repoCidade.Delete(id);
        }
    }
}
