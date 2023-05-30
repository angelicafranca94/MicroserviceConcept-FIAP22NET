using Fiap.Services.CarrinhoAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Services.CarrinhoAPI.Repository
{
    public interface IPromocaoRepository
    {
        Task<PromocaoDTO> GetPromocao(string codigoPromocional);
    }
}
