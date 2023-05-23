using Fiap.Web.Models;
using Fiap.Web.Services.IServices;

namespace Fiap.Web.Services
{
    public class CursoService : BaseService, ICursoService
    {
        private readonly IHttpClientFactory _clientFactory;

        public CursoService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> CreateCursoAsync<T>(CursoViewModel CursoViewModel, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = CursoViewModel,
                Url = SD.CursoAPIBase + "/api/cursos",
                AccessToken = token
            });
        }

        public async Task<T> DeleteCursoAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CursoAPIBase + "/api/cursos/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetAllCursosAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CursoAPIBase + "/api/cursos",
                AccessToken = token
            });
        }

        public async Task<T> GetCursoByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CursoAPIBase + "/api/cursos/" + id,
                AccessToken = token
            });
        }

        public async Task<T> UpdateCursoAsync<T>(CursoViewModel CursoViewModel, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = CursoViewModel,
                Url = SD.CursoAPIBase + "/api/cursos",
                AccessToken = token
            });
        }
    }
}
