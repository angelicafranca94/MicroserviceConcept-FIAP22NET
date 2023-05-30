using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fiap.Services.PromocaoAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPromocaoDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Promocoes",
                columns: table => new
                {
                    PromocaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoPromocional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desconto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocoes", x => x.PromocaoId);
                });

            migrationBuilder.InsertData(
                table: "Promocoes",
                columns: new[] { "PromocaoId", "CodigoPromocional", "Desconto" },
                values: new object[,]
                {
                    { 1, "10OFF", 10.0 },
                    { 2, "20OFF", 20.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promocoes");
        }
    }
}
