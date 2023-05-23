using Microsoft.AspNetCore.Mvc;

namespace Fiap.Services.CarrinhoAPI.Controllers
{
    public class CarinhoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
