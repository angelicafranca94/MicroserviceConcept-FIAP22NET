using Fiap.Web.Models;

namespace Fiap.Web.Services.IServices
{
    public interface IBaseServices : IDisposable
    {
        ResponseViewModel responseModel { get; set; }

        Task<T> SendAsync <T>(ApiRequest apiRequest);
    }
}
