using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Services.PromocaoAPI.Models
{
    public class Promocao
    {
        [Key]
        public int PromocaoId { get; set; }
        public string CodigoPromocional { get; set; }
        public double Desconto { get; set; }
    }
}
