using Fiap.Services.CursoAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Services.CursoAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Curso> Cursos { get; set; }

        // Seed Cursos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Curso>().HasData(new Curso
            {
                CursoId = 1,
                Nome = "MBA FIAP",
                Preco = 2.500,
                Descricao = "Aprenda sobre a organização do projeto com Agile, compreenda a Lógica de Programação básica, codifique, realize a concepção das telas no Front-end, faça a conexão com <br/>banco de dados e Deploy.",
                ImagemURL = "https://storagecursosfiap.blob.core.windows.net/fiap/mbafiap.png",
                Categoria = "MBA"
            });
            modelBuilder.Entity<Curso>().HasData(new Curso
            {
                CursoId = 2,
                Nome = "Cursos Online",
                Preco = 1.599,
                Descricao = "Neste curso, vamos conhecer esta gigante economia de perto, entender o contexto que possibilitou seus grandes avanços, conhecer seus modelos de negócios digitais e nos <br/>aprofundar no sistema de inovação que está transformando o cenário mundial. Em um misto de teoria e prática, também vamos aproximar estes aprendizados à realidade brasileira, estudando<br/> cases reais e discutindo aplicações nos negócios de cada aluno.",
                ImagemURL = "https://storagecursosfiap.blob.core.windows.net/fiap/fiapcursos.png",
                Categoria = "Online"
            });
			modelBuilder.Entity<Curso>().HasData(new Curso
			{
				CursoId = 3,
				Nome = "Cursos gratuitos",
				Preco = 0.00,
				Descricao = "Neste curso, vamos conhecer esta gigante economia de perto, entender o contexto que possibilitou seus grandes avanços, conhecer seus modelos de negócios digitais e nos <br/>aprofundar no sistema de inovação que está transformando o cenário mundial. Em um misto de teoria e prática, também vamos aproximar estes aprendizados à realidade brasileira, estudando<br/> cases reais e discutindo aplicações nos negócios de cada aluno.",
				ImagemURL = "https://storagecursosfiap.blob.core.windows.net/fiap/cursosgratuitos.png",
				Categoria = "Treinamento"
			});
		}
	}
}
