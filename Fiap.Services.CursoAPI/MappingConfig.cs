using AutoMapper;
using Fiap.Services.CursoAPI.Model;
using Fiap.Services.CursoAPI.Model.Dto;

namespace Fiap.Services.CursoAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CursoDTO, Curso>();
                config.CreateMap<Curso, CursoDTO>();
            });

            return mappingConfig;
        }
    }
}
