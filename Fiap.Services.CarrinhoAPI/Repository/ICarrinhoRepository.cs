using Fiap.Services.CarrinhoAPI.Model.Dto;

namespace Fiap.Services.CarrinhoAPI.Repository
{
    public interface ICarrinhoRepository
    {
        Task<IEnumerable<CarrinhoDto>> GetCarrinho();
        Task<CarrinhoDto> AddItemCarrinho();
        Task<bool> DeleteItemCarrinho(int cursoId);
    }
}
