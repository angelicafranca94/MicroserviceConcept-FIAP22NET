using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Models
{
    public class PromocaoDTO
    {
        public int PromocaoId { get; set; }
        public string CodigoPromocional { get; set; }
        public double Desconto { get; set; }
    }
}
