using Fiap.Services.CursoAPI.Model.Dto;
using Fiap.Web.Models;
using Fiap.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace Fiap.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICursoService _cursoService;

        public HomeController(ILogger<HomeController> logger, ICursoService cursoService)
        {
            _logger = logger;
            _cursoService = cursoService;
        }

        public async Task<IActionResult> Index()
        {
            List<CursoDto> list = new();
            var response = await _cursoService.GetAllCursosAsync<ResponseDto>("");
            if (response != null && response.IsSuccess)
            {
                list = JsonSerializer.Deserialize<List<CursoDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        [Authorize]
        public async Task<IActionResult> Details(int cursoId)
        {
            CursoDto model = new();
            var response = await _cursoService.GetCursoByIdAsync<ResponseDto>(cursoId, "");
            if (response != null && response.IsSuccess)
            {
                model = JsonSerializer.Deserialize<CursoDto>(Convert.ToString(response.Result));
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task<IActionResult> Login()
        {
            var access_token = await HttpContext.GetTokenAsync("access_token");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}