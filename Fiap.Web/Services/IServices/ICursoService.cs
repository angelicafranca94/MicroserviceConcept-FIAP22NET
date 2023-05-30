using Fiap.Web.Models;

namespace Fiap.Web.Services.IServices
{
    public interface ICursoService : IBaseService
    {
        Task<T> GetAllCursosAsync<T>(string token);
        Task<T> GetCursoByIdAsync<T>(int id, string token);
        Task<T> CreateCursoAsync<T>(CursoDTO productDto, string token);
        Task<T> UpdateCursoAsync<T>(CursoDTO productDto, string token);
        Task<T> DeleteCursoAsync<T>(int id, string token);
    }
}
