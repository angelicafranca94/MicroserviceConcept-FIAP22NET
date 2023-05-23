using AutoMapper;
using Fiap.Services.CursoAPI.Model;
using Fiap.Services.CursoAPI.Model.Dto;

namespace Fiap.Services.CursoAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegistroMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CursoDto, Curso>();
                config.CreateMap<Curso, CursoDto>();
            });

            return mappingConfig;
        }
    }
}
