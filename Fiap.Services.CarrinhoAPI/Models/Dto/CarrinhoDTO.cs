using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Services.CarrinhoAPI.Models.Dto
{
    public class CarrinhoDTO
    {
        public CarrinhoPedidoDTO CarrinhoPedido { get; set; }
        public IEnumerable<CarrinhoDetalheDTO> CarrinhoDetalhes { get; set; }
    }
}
