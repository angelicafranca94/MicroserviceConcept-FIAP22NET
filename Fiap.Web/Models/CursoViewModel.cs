namespace Fiap.Web.Models
{
    public class CursoViewModel
    {
        public CursoViewModel()
        {
            Count = 1;

        }
      
        public int CursoId { get; set; }
     
        public string Nome { get; set; }
        
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string ImagemURL { get; set; }

        public int Count { get; set; }
    }
}
