using Microsoft.AspNetCore.Mvc;

namespace CpmPedido.Api.Controllers
{
    public class AppBaseController : ControllerBase
    {
        protected readonly IServiceProvider ServiceProvider;

        public AppBaseController(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        protected T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }
    }
}
