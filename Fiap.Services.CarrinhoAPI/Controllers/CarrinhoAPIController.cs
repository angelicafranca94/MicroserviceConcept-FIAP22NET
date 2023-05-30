using Fiap.Services.CarrinhoAPI.Models.Dto;
using Fiap.Services.CarrinhoAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Services.CarrinhoAPI.Controllers
{
    [ApiController]
    [Route("api/carrinho")]
    public class CarrinhoAPIController : Controller
    {
        private readonly ICarrinhoRepository _carrinhoRepository;
        private readonly IPromocaoRepository _promocaoRepository;
        protected ResponseDto _response;

        public CarrinhoAPIController(ICarrinhoRepository carrinhoRepository, 
            IPromocaoRepository promocaoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
            _promocaoRepository = promocaoRepository;

            this._response = new ResponseDto();
        }

        [HttpGet("GetCarrinho/{userId}")]
        public async Task<object> GetCarrinho(string userId)
        {
            try
            {
                CarrinhoDTO carrinhoDto = await _carrinhoRepository.GetCarrinhoByUserId(userId);
                _response.Result = carrinhoDto;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("AddCarrinho")]
        public async Task<object> AddCarrinho(CarrinhoDTO carrinhoDto)
        {
            try
            {
                CarrinhoDTO _carDto = await _carrinhoRepository.CreateUpdateCarrinho(carrinhoDto);
                _response.Result = _carDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("UpdateCarrinho")]
        public async Task<object> UpdateCarrinho(CarrinhoDTO carrinhoDto)
        {
            try
            {
                CarrinhoDTO _carDto = await _carrinhoRepository.CreateUpdateCarrinho(carrinhoDto);
                _response.Result = _carDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("RemoveCarrinho")]
        public async Task<object> RemoveCarrinho([FromBody]int carrinhoId)
        {
            try
            {
                bool isSuccess = await _carrinhoRepository.RemoverDoCarrinho(carrinhoId);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("AplicarPromocao")]
        public async Task<object> AplicarPromocao([FromBody] CarrinhoDTO carrinhoDto)
        {
            try
            {
                bool isSuccess = await _carrinhoRepository.AplicarPromocao(carrinhoDto.CarrinhoPedido.UserId,
                    carrinhoDto.CarrinhoPedido.CodigoPromocional);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("RetirarPromocao")]
        public async Task<object> RetirarPromocao([FromBody] string userId)
        {
            try
            {
                bool isSuccess = await _carrinhoRepository.RetirarPromocao(userId);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }        
    }
}
