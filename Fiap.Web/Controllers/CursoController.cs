using Fiap.Web.Models;
using Fiap.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

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
			List<CursoDTO> list = new List<CursoDTO>();
			var accessToken = await HttpContext.GetTokenAsync("access_token");
			var response = await _cursoService.GetAllCursosAsync<ResponseDTO>(accessToken);
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<CursoDTO>>(Convert.ToString(response.Result));
			}
			return View(list);
		}

		public async Task<IActionResult> CursoCreate()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CursoCreate(CursoDTO model)
		{
			if (ModelState.IsValid)
			{
				var accessToken = await HttpContext.GetTokenAsync("access_token");
				var response = await _cursoService.CreateCursoAsync<ResponseDTO>(model, accessToken);
				if (response != null && response.IsSuccess)
				{
					return RedirectToAction(nameof(CursoIndex));
				}
			}
			return View(model);
		}

		public async Task<IActionResult> CursoEdit(int cursoId)
		{
			var accessToken = await HttpContext.GetTokenAsync("access_token");
			var response = await _cursoService.GetCursoByIdAsync<ResponseDTO>(cursoId, accessToken);
			if (response != null && response.IsSuccess)
			{
				CursoDTO model = JsonConvert.DeserializeObject<CursoDTO>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CursoEdit(CursoDTO model)
		{
			if (ModelState.IsValid)
			{
				var accessToken = await HttpContext.GetTokenAsync("access_token");
				var response = await _cursoService.UpdateCursoAsync<ResponseDTO>(model, accessToken);
				if (response != null && response.IsSuccess)
				{
					return RedirectToAction(nameof(CursoIndex));
				}
			}
			return View(model);
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> CursoDelete(int cursoId)
		{
			var accessToken = await HttpContext.GetTokenAsync("access_token");
			var response = await _cursoService.GetCursoByIdAsync<ResponseDTO>(cursoId, accessToken);
			if (response != null && response.IsSuccess)
			{
				CursoDTO model = JsonConvert.DeserializeObject<CursoDTO>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CursoDelete(CursoDTO model)
		{
			var accessToken = await HttpContext.GetTokenAsync("access_token");
			var response = await _cursoService.DeleteCursoAsync<ResponseDTO>(model.CursoId, accessToken);
			if (response.IsSuccess)
			{
				return RedirectToAction(nameof(CursoIndex));
			}
			return View(model);
		}
	}
}
