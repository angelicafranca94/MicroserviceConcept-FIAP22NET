using Fiap.Services.CursoAPI.Model.Dto;

namespace Fiap.Services.CursoAPI.Repository
{
    public interface ICursoRepository
    {
        Task<IEnumerable<CursoDto>> GetCursos();
        Task<CursoDto> GetCursoById(int cursoId);
        Task<CursoDto> CreateUpdateCurso(CursoDto curso);
        Task<bool> DeleteCurso(int cursoId);
    }
}
