using AutoMapper;
using Fiap.Services.CursoAPI.DbContexts;
using Fiap.Services.CursoAPI.Model;
using Fiap.Services.CursoAPI.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Services.CursoAPI.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public CursoRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CursoDto> CreateUpdateCurso(CursoDto CursoDto)
        {
            Curso curso = _mapper.Map<CursoDto, Curso>(CursoDto);
            if (curso.CursoId > 0)
            {
                _db.Cursos.Update(curso);
            }
            else
            {
                _db.Cursos.Add(curso);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Curso, CursoDto>(curso);
        }

        public async Task<bool> DeleteCurso(int cursoId)
        {
            try
            {
                Curso curso = await _db.Cursos.FirstAsync(u => u.CursoId == cursoId);
                if (curso == null)
                {
                    return false;
                }
                _db.Cursos.Remove(curso);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<CursoDto> GetCursoById(int cursoId)
        {
            Curso curso = await _db.Cursos.Where(x => x.CursoId == cursoId).FirstAsync();
            return _mapper.Map<CursoDto>(curso);
        }

        public async Task<IEnumerable<CursoDto>> GetCursos()
        {
            List<Curso> cursoList = await _db.Cursos.ToListAsync();
            return _mapper.Map<List<CursoDto>>(cursoList);
        }
    }
}
