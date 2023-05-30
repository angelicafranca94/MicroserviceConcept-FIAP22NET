using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Services.CarrinhoAPI.Models.Dto
{
    public class PromocaoDTO
    {
        public int PromocaoId { get; set; }
        public string CodigoPromocional { get; set; }
        public double Desconto { get; set; }
    }
}
