using AutoMapper;
using Fiap.Services.CarrinhoAPI.Models;
using Fiap.Services.CarrinhoAPI.Models.Dto;

namespace Fiap.Services.CarrinhoAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Curso, CursoDTO>().ReverseMap();
                config.CreateMap<CarrinhoPedido, CarrinhoPedidoDTO>().ReverseMap();
                config.CreateMap<CarrinhoDetalhe, CarrinhoDetalheDTO>().ReverseMap();
                config.CreateMap<Carrinho, CarrinhoDTO>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
