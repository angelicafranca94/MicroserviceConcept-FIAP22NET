using Fiap.Web.Models;
using Fiap.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly ICursoService _cursoService;
        private readonly ICarrinhoService _carrinhoService;
        private readonly IPromocaoService _promocaoService;
        public CarrinhoController(ICursoService cursoService, ICarrinhoService carrinhoService, 
            IPromocaoService promocaoService)
        {
            _cursoService = cursoService;
            _promocaoService = promocaoService;
            _carrinhoService = carrinhoService;
        }
        public async Task<IActionResult> CarrinhoIndex()
        {
            return View(await Carregar_CarrinhoDtoBasedOnLoggedInUser());
        }

        [HttpPost]
        [ActionName("AplicarDesconto")]
        public async Task<IActionResult> AplicarDesconto(CarrinhoDTO carrinhoDto)
        {
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _carrinhoService.AplicarDesconto<ResponseDTO>(carrinhoDto, accessToken);

            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(CarrinhoIndex));
            }
            return View();
        }

        [HttpPost]
        [ActionName("RetirarDesconto")]
        public async Task<IActionResult> RetirarDesconto(CarrinhoDTO carrinhoDto)
        {
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _carrinhoService.RetirarDesconto<ResponseDTO>(carrinhoDto.CarrinhoPedido.UserId, accessToken);

            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(CarrinhoIndex));
            }
            return View();
        }

        public async Task<IActionResult> Remove(int carrinhoDetalheId)
        {
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _carrinhoService.RemoverDoCarrinhoAsync<ResponseDTO>(carrinhoDetalheId, accessToken);

            
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(CarrinhoIndex));
            }
            return View();
        }

      
        public async Task<IActionResult> Checkout()
        {
            return View(await Carregar_CarrinhoDtoBasedOnLoggedInUser());
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CarrinhoDTO carrinhoDto) 
        {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _carrinhoService.Checkout<ResponseDTO>(carrinhoDto.CarrinhoPedido, accessToken);
                if (!response.IsSuccess)
                {
                    TempData["Error"] = response.DisplayMessage;
                    return RedirectToAction(nameof(Checkout));
                }
                return RedirectToAction(nameof(Confirmacao));
            }
            catch(Exception e)
            {
                return View(carrinhoDto);
            }
        }
       
        public async Task<IActionResult> Confirmacao()
        {
            return View();
        }
        private async Task<CarrinhoDTO> Carregar_CarrinhoDtoBasedOnLoggedInUser()
        {
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _carrinhoService.GetCarrinhoByUserIdAsnyc<ResponseDTO>(userId, accessToken);

            CarrinhoDTO carrinhoDto = new();
            if(response!=null && response.IsSuccess)
            {
                carrinhoDto = JsonConvert.DeserializeObject<CarrinhoDTO>(Convert.ToString(response.Result));
            }

            if (carrinhoDto.CarrinhoPedido != null)
            {
                if (!string.IsNullOrEmpty(carrinhoDto.CarrinhoPedido.CodigoPromocional))
                {
                    var desconto = await _promocaoService.GetPromocao<ResponseDTO>(carrinhoDto.CarrinhoPedido.CodigoPromocional, accessToken);
                    if (desconto != null && desconto.IsSuccess)
                    {
                        var descontoObj = JsonConvert.DeserializeObject<PromocaoDTO>(Convert.ToString(desconto.Result));
                        carrinhoDto.CarrinhoPedido.DescontoTotal = descontoObj.Desconto;
                    }
                }

                foreach (var detail in carrinhoDto.CarrinhoDetalhe) {
                    carrinhoDto.CarrinhoPedido.TotalDoPedido += (detail.Curso.Preco * detail.Count);
                }

                carrinhoDto.CarrinhoPedido.TotalDoPedido -= carrinhoDto.CarrinhoPedido.DescontoTotal;
            }
            return carrinhoDto;
        }
    }
}
