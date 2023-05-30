using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Services.CarrinhoAPI.Models
{
    public class Curso
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CursoId { get; set; }
        [Required]
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string ImagemUrl { get; set; }
    }
}
