using AutoMapper;
using Fiap.Services.PromocaoAPI.Models;
using Fiap.Services.PromocaoAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Services.PromocaoAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PromocaoDTO, Promocao>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
