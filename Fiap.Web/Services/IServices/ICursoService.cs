using Fiap.Web.Models;

namespace Fiap.Web.Services.IServices
{
    public interface ICursoService
    {
        Task<T> GetAllCursosAsync<T>(string token);
        Task<T> GetCursoByIdAsync<T>(int id, string token);
        Task<T> CreateCursoAsync<T>(CursoViewModel model, string token);
        Task<T> UpdateCursoAsync<T>(CursoViewModel model, string token);
        Task<T> DeleteCursoAsync<T>(int id, string token);
    }
}
