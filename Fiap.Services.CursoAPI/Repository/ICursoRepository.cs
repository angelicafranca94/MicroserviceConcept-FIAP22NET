using Fiap.Services.CursoAPI.Model.Dto;

namespace Fiap.Services.CursoAPI.Repository
{
    public interface ICursoRepository
    {
        Task<IEnumerable<CursoDTO>> GetCursos();
        Task<CursoDTO> GetCursoById(int cursoId);
        Task<CursoDTO> CreateUpdateCurso(CursoDTO cursoDto);
        Task<bool> DeleteCurso(int cursoId);
    }
}
