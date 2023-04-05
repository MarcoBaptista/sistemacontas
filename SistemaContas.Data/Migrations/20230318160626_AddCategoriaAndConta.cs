using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaContas.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriaAndConta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIA",
                columns: table => new
                {
                    IDCATEGORIA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TIPO = table.Column<int>(type: "int", nullable: false),
                    IDUSUARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA", x => x.IDCATEGORIA);
                    table.ForeignKey(
                        name: "FK_CATEGORIA_USUARIO_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "IDUSUARIO");
                });

            migrationBuilder.CreateTable(
                name: "CONTA",
                columns: table => new
                {
                    IDCONTA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DATA = table.Column<DateTime>(type: "datetime", nullable: false),
                    VALOR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IDUSUARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDCATEGORIA = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTA", x => x.IDCONTA);
                    table.ForeignKey(
                        name: "FK_CONTA_CATEGORIA_IDCATEGORIA",
                        column: x => x.IDCATEGORIA,
                        principalTable: "CATEGORIA",
                        principalColumn: "IDCATEGORIA");
                    table.ForeignKey(
                        name: "FK_CONTA_USUARIO_IDUSUARIO",
                        column: x => x.IDUSUARIO,
                        principalTable: "USUARIO",
                        principalColumn: "IDUSUARIO");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIA_IDUSUARIO",
                table: "CATEGORIA",
                column: "IDUSUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_IDCATEGORIA",
                table: "CONTA",
                column: "IDCATEGORIA");

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_IDUSUARIO",
                table: "CONTA",
                column: "IDUSUARIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTA");

            migrationBuilder.DropTable(
                name: "CATEGORIA");
        }
    }
}
