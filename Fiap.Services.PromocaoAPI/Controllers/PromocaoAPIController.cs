using Fiap.Services.PromocaoAPI.Models.Dto;
using Fiap.Services.PromocaoAPI.Respository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Services.PromocaoAPI.Controllers
{
    [ApiController]
    [Route("api/promocao")]
    public class PromocaoAPIController : Controller
    {
        private readonly IPromocaoRepository _promocaoRepository;
        protected ResponseDTO _response;

        public PromocaoAPIController(IPromocaoRepository promocaoRepository)
        {
            _promocaoRepository = promocaoRepository;
            this._response = new ResponseDTO();
        }

        [HttpGet("{codigo}")]
        public async Task<object> GetDescontoPorCodigo(string codigoPromocional)
        {
            try
            {
                var codigo = await _promocaoRepository.GetCodigoPromocional(codigoPromocional);
                _response.Result = codigo;
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
