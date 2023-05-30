using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Services.CarrinhoAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCarrinhoDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarrinhoPedidos",
                columns: table => new
                {
                    CarrinhoPedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPromocional = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoPedidos", x => x.CarrinhoPedidoId);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.CreateTable(
                name: "CarrinhoDetalhes",
                columns: table => new
                {
                    CarrinhoDetalheId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrinhoPedidoId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoDetalhes", x => x.CarrinhoDetalheId);
                    table.ForeignKey(
                        name: "FK_CarrinhoDetalhes_CarrinhoPedidos_CarrinhoPedidoId",
                        column: x => x.CarrinhoPedidoId,
                        principalTable: "CarrinhoPedidos",
                        principalColumn: "CarrinhoPedidoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarrinhoDetalhes_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoDetalhes_CarrinhoPedidoId",
                table: "CarrinhoDetalhes",
                column: "CarrinhoPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoDetalhes_CursoId",
                table: "CarrinhoDetalhes",
                column: "CursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoDetalhes");

            migrationBuilder.DropTable(
                name: "CarrinhoPedidos");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
