namespace Fiap.Services.CursoAPI.Model.Dto
{
    public class CursoDto
    {
      
        public int CursoId { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string ImagemURL { get; set; }
    }
}
