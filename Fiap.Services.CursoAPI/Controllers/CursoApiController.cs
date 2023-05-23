
using Fiap.Services.CursoAPI.Model.Dto;
using Fiap.Services.CursoAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Services.CursoAPI.Controllers
{
    [Route("api/cursos")]
    public class CursoAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private ICursoRepository _cursoRepository;

        public CursoAPIController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
            this._response = new ResponseDto();
        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<CursoDto> CursoDtos = await _cursoRepository.GetCursos();
                _response.Result = CursoDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                CursoDto CursoDto = await _cursoRepository.GetCursoById(id);
                _response.Result = CursoDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPost]
        //[Authorize]
        public async Task<object> Post([FromBody] CursoDto CursoDto)
        {
            try
            {
                CursoDto model = await _cursoRepository.CreateUpdateCurso(CursoDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPut]
       // [Authorize]
        public async Task<object> Put([FromBody] CursoDto CursoDto)
        {
            try
            {
                CursoDto model = await _cursoRepository.CreateUpdateCurso(CursoDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
       // [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _cursoRepository.DeleteCurso(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
