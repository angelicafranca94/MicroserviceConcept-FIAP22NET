using Fiap.Services.PromocaoAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Services.PromocaoAPI.Respository
{
    public interface IPromocaoRepository
    {
        Task<PromocaoDTO> GetCodigoPromocional(string codigoPromocional);
    }
}
