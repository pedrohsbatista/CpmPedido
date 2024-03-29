﻿using CpmPedido.Domain.Dtos;
using CpmPedido.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CpmPedido.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]   
    public class PedidoController : AppBaseController
    {
        public PedidoController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [HttpGet]
        [Route("ticketmaximum")]
        public decimal GetTicketMaximum()
        {
            var repoPedido = GetService<IPedidoRepository>();
            return repoPedido.TicketMaximum();
        }

        [HttpGet]
        [Route("bycliente")]
        public dynamic GetByCliente()
        {
            var repoPedido = GetService<IPedidoRepository>();
            return repoPedido.ByCliente();
        }

        [HttpPost]
        public string Post(PedidoDto pedidoDto)
        {
            var repoPedido = GetService<IPedidoRepository>();
            return repoPedido.Insert(pedidoDto);
        }
    }
}
