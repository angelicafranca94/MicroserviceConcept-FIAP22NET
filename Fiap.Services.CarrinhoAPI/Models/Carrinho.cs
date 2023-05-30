using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Services.CarrinhoAPI.Models
{
    public class Carrinho
    {
        public CarrinhoPedido CarrinhoPedido { get; set; }
        public IEnumerable<CarrinhoDetalhe> CarrinhoDetalhe { get; set; }
    }
}
