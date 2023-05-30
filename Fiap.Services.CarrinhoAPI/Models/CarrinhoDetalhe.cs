using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Services.CarrinhoAPI.Models
{
    public class CarrinhoDetalhe
    {
        public int CarrinhoDetalheId { get; set; }
        public int CarrinhoPedidoId { get; set; }
        [ForeignKey("CarrinhoPedidoId")]
        public virtual CarrinhoPedido CarrinhoPedido { get; set; }
        public int CursoId { get; set; }
        [ForeignKey("CursoId")]
        public virtual Curso Curso { get; set; }
        public int Count { get; set; }
    }
}
