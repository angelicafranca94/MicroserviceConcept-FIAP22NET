using Fiap.Web.Models;
using Fiap.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fiap.Web.Services
{
    public class PromocaoService : BaseService, IPromocaoService
    {
        private readonly IHttpClientFactory _clientFactory;

        public PromocaoService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> GetPromocao<T>(string codigoPromocional, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.PromocaoAPIBase + "/api/promocao/" + codigoPromocional,
                AccessToken = token
            });
        }
    }
}
