using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Services.CursoAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedAtualizar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 1,
                columns: new[] { "Categoria", "ImagemURL", "Nome", "Preco" },
                values: new object[] { "MBA", "https://storagecursosfiap.blob.core.windows.net/fiap/mbafiap.png", "MBA FIAP", 2.5 });

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 2,
                columns: new[] { "Categoria", "ImagemURL", "Nome" },
                values: new object[] { "Online", "https://storagecursosfiap.blob.core.windows.net/fiap/fiapcursos.png", "Cursos Online" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Categoria", "Descricao", "ImagemURL", "Nome", "Preco" },
                values: new object[] { 3, "Treinamento", "Neste curso, vamos conhecer esta gigante economia de perto, entender o contexto que possibilitou seus grandes avanços, conhecer seus modelos de negócios digitais e nos <br/>aprofundar no sistema de inovação que está transformando o cenário mundial. Em um misto de teoria e prática, também vamos aproximar estes aprendizados à realidade brasileira, estudando<br/> cases reais e discutindo aplicações nos negócios de cada aluno.", "https://storagecursosfiap.blob.core.windows.net/fiap/cursosgratuitos.png", "Cursos gratuitos", 0.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 1,
                columns: new[] { "Categoria", "ImagemURL", "Nome", "Preco" },
                values: new object[] { "Curta", "", "Mastering C#", 1500.0 });

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 2,
                columns: new[] { "Categoria", "ImagemURL", "Nome" },
                values: new object[] { "Curta", "", "China, Tecnologia e Inovação" });
        }
    }
}
