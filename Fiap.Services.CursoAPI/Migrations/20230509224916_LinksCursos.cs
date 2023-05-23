using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Services.CursoAPI.Migrations
{
    /// <inheritdoc />
    public partial class LinksCursos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 1,
                columns: new[] { "Categoria", "ImagemURL" },
                values: new object[] { "Treinamento", "https://storagecursosfiap.blob.core.windows.net/fiap/cursosgratuitos.png" });

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 2,
                columns: new[] { "ImagemURL", "Nome" },
                values: new object[] { "https://storagecursosfiap.blob.core.windows.net/fiap/fiapcursos.png", "Pós Graduação FIAP" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Categoria", "Descricao", "ImagemURL", "Nome", "Preco" },
                values: new object[] { 3, "Curta", "Neste curso, vamos conhecer esta gigante economia de perto, entender o contexto que possibilitou seus grandes avanços, conhecer seus modelos de negócios digitais e nos <br/>aprofundar no sistema de inovação que está transformando o cenário mundial. Em um misto de teoria e prática, também vamos aproximar estes aprendizados à realidade brasileira, estudando<br/> cases reais e discutindo aplicações nos negócios de cada aluno.", "https://storagecursosfiap.blob.core.windows.net/fiap/mbafiap.png", ".NET Engenharia & Arquitetura", 1.599 });
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
                columns: new[] { "Categoria", "ImagemURL" },
                values: new object[] { "Curta", "" });

            migrationBuilder.UpdateData(
                table: "Cursos",
                keyColumn: "CursoId",
                keyValue: 2,
                columns: new[] { "ImagemURL", "Nome" },
                values: new object[] { "", "China, Tecnologia e Inovação" });
        }
    }
}
