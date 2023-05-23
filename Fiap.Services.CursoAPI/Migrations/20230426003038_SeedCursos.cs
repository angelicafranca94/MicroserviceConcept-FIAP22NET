using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fiap.Services.CursoAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedCursos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Categoria", "Descricao", "ImagemURL", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, "Curta", "Aprenda sobre a organização do projeto com Agile, compreenda a Lógica de Programação básica, codifique, realize a concepção das telas no Front-end, faça a conexão com <br/>banco de dados e Deploy.", "", "Mastering C#", 1500.0 },
                    { 2, "Curta", "Neste curso, vamos conhecer esta gigante economia de perto, entender o contexto que possibilitou seus grandes avanços, conhecer seus modelos de negócios digitais e nos <br/>aprofundar no sistema de inovação que está transformando o cenário mundial. Em um misto de teoria e prática, também vamos aproximar estes aprendizados à realidade brasileira, estudando<br/> cases reais e discutindo aplicações nos negócios de cada aluno.", "", "China, Tecnologia e Inovação", 1.599 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 2);
        }
    }
}
