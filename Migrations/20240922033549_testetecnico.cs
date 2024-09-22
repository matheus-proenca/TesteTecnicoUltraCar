using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Testetecnico_Ultracar.Migrations
{
    /// <inheritdoc />
    public partial class testetecnico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orcamentos",
                columns: table => new
                {
                    OrcamentoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeCliente = table.Column<string>(type: "text", nullable: false),
                    PlacaVeiculo = table.Column<string>(type: "text", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamentos", x => x.OrcamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Entrega",
                columns: table => new
                {
                    EntregaId = table.Column<int>(type: "integer", nullable: false),
                    Cep = table.Column<int>(type: "integer", nullable: false),
                    OrcamentoId = table.Column<int>(type: "integer", nullable: false),
                    PecaId = table.Column<int>(type: "integer", nullable: false),
                    EstadoDeEspera = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrega", x => x.EntregaId);
                    table.ForeignKey(
                        name: "FK_Entrega_Orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamentos",
                        principalColumn: "OrcamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pecas",
                columns: table => new
                {
                    PecaId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    QuantidadeEstoque = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pecas", x => x.PecaId);
                    table.ForeignKey(
                        name: "FK_Pecas_Entrega_PecaId",
                        column: x => x.PecaId,
                        principalTable: "Entrega",
                        principalColumn: "EntregaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pecas_Orcamentos_PecaId",
                        column: x => x.PecaId,
                        principalTable: "Orcamentos",
                        principalColumn: "OrcamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estoques",
                columns: table => new
                {
                    EstoqueId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PecaId = table.Column<int>(type: "integer", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    EntregaId = table.Column<int>(type: "integer", nullable: false),
                    Enviado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Entregue = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoques", x => x.EstoqueId);
                    table.ForeignKey(
                        name: "FK_Estoques_Pecas_PecaId",
                        column: x => x.PecaId,
                        principalTable: "Pecas",
                        principalColumn: "PecaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuantidadePecas",
                columns: table => new
                {
                    QuantidadePecaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrcamentoId = table.Column<int>(type: "integer", nullable: false),
                    PecaId = table.Column<int>(type: "integer", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantidadePecas", x => x.QuantidadePecaId);
                    table.ForeignKey(
                        name: "FK_QuantidadePecas_Orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamentos",
                        principalColumn: "OrcamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuantidadePecas_Pecas_PecaId",
                        column: x => x.PecaId,
                        principalTable: "Pecas",
                        principalColumn: "PecaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_OrcamentoId",
                table: "Entrega",
                column: "OrcamentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_PecaId",
                table: "Estoques",
                column: "PecaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuantidadePecas_OrcamentoId",
                table: "QuantidadePecas",
                column: "OrcamentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuantidadePecas_PecaId",
                table: "QuantidadePecas",
                column: "PecaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Entrega_Estoques_EntregaId",
                table: "Entrega",
                column: "EntregaId",
                principalTable: "Estoques",
                principalColumn: "EstoqueId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrega_Estoques_EntregaId",
                table: "Entrega");

            migrationBuilder.DropTable(
                name: "QuantidadePecas");

            migrationBuilder.DropTable(
                name: "Estoques");

            migrationBuilder.DropTable(
                name: "Pecas");

            migrationBuilder.DropTable(
                name: "Entrega");

            migrationBuilder.DropTable(
                name: "Orcamentos");
        }
    }
}
