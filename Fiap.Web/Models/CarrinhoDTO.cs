using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Models
{
    public class CarrinhoDTO
    {
        public CarrinhoPedidoDTO CarrinhoPedido { get; set; }
        public IEnumerable<CarrinhoDetalheDTO> CarrinhoDetalhe { get; set; }
    }
}
