using Fiap.Services.CarrinhoAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Services.CarrinhoAPI.Repository
{
    public interface ICarrinhoRepository
    {
        Task<CarrinhoDTO> GetCarrinhoByUserId(string userId);
        Task<CarrinhoDTO> CreateUpdateCarrinho(CarrinhoDTO carrinhoDTO);
        Task<bool> RemoverDoCarrinho(int carrinhoDetalheId);
        Task<bool> AplicarPromocao(string userId, string codigoPromocional);
        Task<bool> RetirarPromocao(string userId);
        Task<bool> LimparCarrinho(string userId);
    }
}
