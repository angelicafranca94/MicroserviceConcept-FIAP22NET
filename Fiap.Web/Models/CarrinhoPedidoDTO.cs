using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Models
{
    public class CarrinhoPedidoDTO
    {
        public int CarrinhoPedidoId { get; set; }
        public string UserId { get; set; }
        public string CodigoPromocional{ get; set; }
        public double TotalDoPedido { get; set; }
        public double DescontoTotal { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DataDoPedido { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CartaoDeCredito { get; set; }
        public string CVV { get; set; }
        public string DataValidadeCartao { get; set; }
    }
}
