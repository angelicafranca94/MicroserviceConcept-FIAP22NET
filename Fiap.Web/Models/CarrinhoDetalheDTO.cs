using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Models
{
    public class CarrinhoDetalheDTO
    {
        public int CarrinhoDetalhesId { get; set; }
        public int CarrinhoPedidoId { get; set; }
        public virtual CarrinhoPedidoDTO CarrinhoPedido{ get; set; }
        public int CursoId { get; set; }
        public virtual CursoDTO Curso { get; set; }
        public int Count { get; set; }
    }
}
