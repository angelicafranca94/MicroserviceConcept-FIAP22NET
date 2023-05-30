using Fiap.Web.Models;
using Fiap.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fiap.Web.Services
{
    public class CarrinhoService : BaseService, ICarrinhoService
    {
        private readonly IHttpClientFactory _clientFactory;

        public CarrinhoService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> AdicionarNoCarrinhoAsync<T>(CarrinhoDTO carrinhoDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = carrinhoDto,
                Url = SD.CarrinhoAPIBase + "/api/carrinho/AddCarrinho",
                AccessToken = token
            });
        }

        public async Task<T> AplicarDesconto<T>(CarrinhoDTO carrinhoDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = carrinhoDto,
                Url = SD.CarrinhoAPIBase + "/api/carrinho/AplicarDesconto",
                AccessToken = token
            });
        }

        public async Task<T> Checkout<T>(CarrinhoPedidoDTO carrinhoPedido, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = carrinhoPedido,
                Url = SD.CarrinhoAPIBase + "/api/carrinho/checkout",
                AccessToken = token
            });
        }

        public async Task<T> GetCarrinhoByUserIdAsnyc<T>(string userId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CarrinhoAPIBase + "/api/carrinho/GetCarrinho/" + userId,
                AccessToken = token
            });
        }

        public async Task<T> RetirarDesconto<T>(string userId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = userId,
                Url = SD.CarrinhoAPIBase + "/api/carrinho/RetirarDesconto",
                AccessToken = token
            });
        }

        public async Task<T> RemoverDoCarrinhoAsync<T>(int cartId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = cartId,
                Url = SD.CarrinhoAPIBase + "/api/carrinho/RemoverDoCarrinhoAsync",
                AccessToken = token
            });
        }

        public async Task<T> UpdateCarrinhoAsync<T>(CarrinhoDTO carrinhoDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = carrinhoDto,
                Url = SD.CarrinhoAPIBase + "/api/carrinho/UpdateCarrinho",
                AccessToken = token
            });
        }
    }
}
