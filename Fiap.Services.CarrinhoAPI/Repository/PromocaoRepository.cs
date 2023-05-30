using Fiap.Services.CarrinhoAPI.Models.Dto;
using Fiap.Services.CarrinhoAPI.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fiap.Services.CarrinhoAPI.Repository
{
    public class PromocaoRepository : IPromocaoRepository
    {
        private readonly HttpClient client;

        public PromocaoRepository(HttpClient client)
        {
            this.client = client;
        }

        public async Task<PromocaoDTO> GetPromocao(string codigoPromocional)
        {
            var response = await client.GetAsync($"/api/coupon/{codigoPromocional}");
            var apiContent = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<PromocaoDTO>(Convert.ToString(resp.Result));
            }
            return new PromocaoDTO();
        }
    }
}
