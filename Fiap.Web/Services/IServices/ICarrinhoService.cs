using Fiap.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Services.IServices
{
    public interface ICarrinhoService
    {
        Task<T> GetCarrinhoByUserIdAsnyc<T>(string userId, string token = null);
        Task<T> AdicionarNoCarrinhoAsync<T>(CarrinhoDTO carrinhoDto, string token = null);
        Task<T> UpdateCarrinhoAsync<T>(CarrinhoDTO carrinhoDto, string token = null);
        Task<T> RemoverDoCarrinhoAsync<T>(int cartId, string token = null);
        Task<T> AplicarDesconto<T>(CarrinhoDTO carrinhoDto, string token = null);
        Task<T> RetirarDesconto<T>(string userId, string token = null);

        Task<T> Checkout<T>(CarrinhoPedidoDTO carrinhoPedido, string token = null);
    }
}
