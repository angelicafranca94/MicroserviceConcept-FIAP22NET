using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Fiap.Services.CursoAPI.Model
{
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Range(1,10000)]
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string ImagemURL { get; set; }
    }
}
