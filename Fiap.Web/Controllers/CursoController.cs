using Fiap.Web.Models;
using Fiap.Web.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Fiap.Web.Controllers
{
    public class CursoController : Controller
    {
		private readonly ICursoService _cursoService;
		public CursoController(ICursoService cursoService)
		{
			_cursoService = cursoService;
		}

		public async Task<IActionResult> CursoIndex()
		{
			List<CursoViewModel> list = new List<CursoViewModel>();
			//var accessToken = await HttpContext.GetTokenAsync("access_token");
			var response = await _cursoService.GetAllCursosAsync<ResponseViewModel>("");
			if (response != null && response.IsSuccess)
			{
				list = JsonSerializer.Deserialize<List<CursoViewModel>>(Convert.ToString(response.Result));
			}
			return View(list);
		}

		public async Task<IActionResult> CursoCreate()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CursoCreate(CursoViewModel model)
		{
			if (ModelState.IsValid)
			{
				var response = await _cursoService.CreateCursoAsync<ResponseViewModel>(model, "");
				if (response != null && response.IsSuccess)
				{
					return RedirectToAction(nameof(CursoIndex));
				}
			}
			return View(model);
		}

		public async Task<IActionResult> CursoEdit(int cursoId)
		{
			//var accessToken = await HttpContext.GetTokenAsync("access_token");
			var response = await _cursoService.GetCursoByIdAsync<ResponseViewModel>(cursoId, "");
			if (response != null && response.IsSuccess)
			{
				CursoViewModel model = JsonSerializer.Deserialize<CursoViewModel>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CursoEdit(CursoViewModel model)
		{
			if (ModelState.IsValid)
			{
				// var accessToken = await HttpContext.GetTokenAsync("access_token");
				var response = await _cursoService.UpdateCursoAsync<ResponseViewModel>(model, "");
				if (response != null && response.IsSuccess)
				{
					return RedirectToAction(nameof(CursoIndex));
				}
			}
			return View(model);
		}

		//[Authorize(Roles = "Admin")]
		public async Task<IActionResult> CursoDelete(int cursoId)
		{
			// var accessToken = await HttpContext.GetTokenAsync("access_token");
			var response = await _cursoService.GetCursoByIdAsync<ResponseViewModel>(cursoId, "");
			if (response != null && response.IsSuccess)
			{
				CursoViewModel model = JsonSerializer.Deserialize<CursoViewModel>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		[HttpPost]
		// [Authorize(Roles = "Admin")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CursoDelete(CursoViewModel model)
		{
			// var accessToken = await HttpContext.GetTokenAsync("access_token");
			var response = await _cursoService.DeleteCursoAsync<ResponseViewModel>(model.CursoId, "");
			if (response.IsSuccess)
			{
				return RedirectToAction(nameof(CursoIndex));
			}
			return View(model);
		}
	}
}
