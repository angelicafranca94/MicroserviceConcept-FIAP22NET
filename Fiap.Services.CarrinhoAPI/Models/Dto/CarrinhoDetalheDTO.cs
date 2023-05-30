using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Services.CarrinhoAPI.Models.Dto
{
    public class CarrinhoDetalheDTO
    {
        public int CarrinhoDetalheId { get; set; }
        public int CarrinhoPedidoId { get; set; }
        public virtual CarrinhoPedidoDTO CarrinhoPedidoDTO { get; set; }
        public int CursoId { get; set; }
        public virtual CursoDTO Curso { get; set; }
        public int Count { get; set; }
    }
}
