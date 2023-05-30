using Fiap.Web.Models;
using Fiap.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Fiap.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly ICursoService _cursoService;
        private readonly ICarrinhoService _carrinhoService;

        public HomeController(ILogger<HomeController> logger, ICursoService cursoService,
            ICarrinhoService carrinhoService)
        {
            _logger = logger;
            _cursoService = cursoService;
            _carrinhoService = carrinhoService;
        }

		public async Task<IActionResult> Index()
		{
			List<CursoDTO> list = new();
			var response = await _cursoService.GetAllCursosAsync<ResponseDTO>("");
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<CursoDTO>>(Convert.ToString(response.Result));
			}
			return View(list);
		}

        [Authorize]
        public async Task<IActionResult> Details(int cursoId)
        {
            CursoDTO model = new();
            var response = await _cursoService.GetCursoByIdAsync<ResponseDTO>(cursoId, "");
            if (response != null && response.IsSuccess)
            {
                model = JsonConvert.DeserializeObject<CursoDTO>(Convert.ToString(response.Result));
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Details")]
        [Authorize]
        public async Task<IActionResult> DetailsPost(CursoDTO cursoDto)
        {
            CarrinhoDTO carrinhoDto = new()
            {
                CarrinhoPedido = new CarrinhoPedidoDTO
                {
                    UserId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value
                }
            };

            CarrinhoDetalheDTO carrinhiDetalhe = new CarrinhoDetalheDTO()
            {
                Count = cursoDto.Count,
                CursoId = cursoDto.CursoId
            };

            var resp = await _cursoService.GetCursoByIdAsync<ResponseDTO>(cursoDto.CursoId, "");
            if (resp != null && resp.IsSuccess)
            {
                carrinhiDetalhe.Curso = JsonConvert.DeserializeObject<CursoDTO>(Convert.ToString(resp.Result));
            }
            List<CarrinhoDetalheDTO> carrinhoDetalheDtos = new();
            carrinhoDetalheDtos.Add(carrinhiDetalhe);
            carrinhoDto.CarrinhoDetalhe = carrinhoDetalheDtos;

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var adicionarResponse = await _carrinhoService.AdicionarNoCarrinhoAsync<ResponseDTO>(carrinhoDto, accessToken);
            if (adicionarResponse != null && adicionarResponse.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(cursoDto);
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

        // Adicionar referencia a tela de login e logout

        [Authorize]
        public IActionResult Login()
        {
            return RedirectToAction(nameof(Index));
        }

		public IActionResult Logout()
		{
			return SignOut("Cookies", "oidc");
		}
	}
}