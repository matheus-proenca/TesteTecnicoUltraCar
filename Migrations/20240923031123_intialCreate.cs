using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Testetecnico_Ultracar.Migrations
{
    /// <inheritdoc />
    public partial class intialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orcamento",
                columns: table => new
                {
                    OrcamentoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeCliente = table.Column<string>(type: "text", nullable: false),
                    Cep = table.Column<int>(type: "integer", nullable: false),
                    PlacaVeiculo = table.Column<string>(type: "text", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamento", x => x.OrcamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Entrega",
                columns: table => new
                {
                    EntregaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cep = table.Column<int>(type: "integer", nullable: false),
                    OrcamentoId = table.Column<int>(type: "integer", nullable: false),
                    PecaId = table.Column<int>(type: "integer", nullable: false),
                    quantidadeEnviada = table.Column<int>(type: "integer", nullable: false),
                    EstadoDeEspera = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrega", x => x.EntregaId);
                    table.ForeignKey(
                        name: "FK_Entrega_Orcamento_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamento",
                        principalColumn: "OrcamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    EstoqueId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EntregaId = table.Column<int>(type: "integer", nullable: false),
                    Enviado = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Entregue = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.EstoqueId);
                    table.ForeignKey(
                        name: "FK_Estoque_Entrega_EntregaId",
                        column: x => x.EntregaId,
                        principalTable: "Entrega",
                        principalColumn: "EntregaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Peca",
                columns: table => new
                {
                    PecaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    QuantidadeEstoque = table.Column<int>(type: "integer", nullable: false),
                    EstoqueId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peca", x => x.PecaId);
                    table.ForeignKey(
                        name: "FK_Peca_Estoque_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "Estoque",
                        principalColumn: "EstoqueId");
                });

            migrationBuilder.CreateTable(
                name: "QuantidadePeca",
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
                    table.PrimaryKey("PK_QuantidadePeca", x => x.QuantidadePecaId);
                    table.ForeignKey(
                        name: "FK_QuantidadePeca_Orcamento_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamento",
                        principalColumn: "OrcamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuantidadePeca_Peca_PecaId",
                        column: x => x.PecaId,
                        principalTable: "Peca",
                        principalColumn: "PecaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_OrcamentoId",
                table: "Entrega",
                column: "OrcamentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_PecaId",
                table: "Entrega",
                column: "PecaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_EntregaId",
                table: "Estoque",
                column: "EntregaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Peca_EstoqueId",
                table: "Peca",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_QuantidadePeca_OrcamentoId",
                table: "QuantidadePeca",
                column: "OrcamentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuantidadePeca_PecaId",
                table: "QuantidadePeca",
                column: "PecaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Entrega_Peca_PecaId",
                table: "Entrega",
                column: "PecaId",
                principalTable: "Peca",
                principalColumn: "PecaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrega_Orcamento_OrcamentoId",
                table: "Entrega");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrega_Peca_PecaId",
                table: "Entrega");

            migrationBuilder.DropTable(
                name: "QuantidadePeca");

            migrationBuilder.DropTable(
                name: "Orcamento");

            migrationBuilder.DropTable(
                name: "Peca");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "Entrega");
        }
    }
}
