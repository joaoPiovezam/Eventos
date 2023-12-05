using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventos.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    local = table.Column<string>(type: "TEXT", nullable: true),
                    dataEvento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    tema = table.Column<string>(type: "TEXT", nullable: true),
                    qtdPessoas = table.Column<int>(type: "INTEGER", nullable: false),
                    lote = table.Column<string>(type: "TEXT", nullable: true),
                    imagemURL = table.Column<string>(type: "TEXT", nullable: true),
                    telefone = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Palestrantes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    descricao = table.Column<string>(type: "TEXT", nullable: true),
                    imagemURL = table.Column<string>(type: "TEXT", nullable: true),
                    telefone = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palestrantes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Lotes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    preco = table.Column<decimal>(type: "TEXT", nullable: false),
                    dataInicio = table.Column<DateTime>(type: "TEXT", nullable: true),
                    dataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    qtd = table.Column<int>(type: "INTEGER", nullable: false),
                    eventoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Lotes_Eventos_eventoId",
                        column: x => x.eventoId,
                        principalTable: "Eventos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PalestrantesEventos",
                columns: table => new
                {
                    palestranteId = table.Column<int>(type: "INTEGER", nullable: false),
                    eventoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalestrantesEventos", x => new { x.eventoId, x.palestranteId });
                    table.ForeignKey(
                        name: "FK_PalestrantesEventos_Eventos_eventoId",
                        column: x => x.eventoId,
                        principalTable: "Eventos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PalestrantesEventos_Palestrantes_palestranteId",
                        column: x => x.palestranteId,
                        principalTable: "Palestrantes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RedesSociais",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    URL = table.Column<string>(type: "TEXT", nullable: true),
                    eventoId = table.Column<int>(type: "INTEGER", nullable: true),
                    palestranteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedesSociais", x => x.id);
                    table.ForeignKey(
                        name: "FK_RedesSociais_Eventos_eventoId",
                        column: x => x.eventoId,
                        principalTable: "Eventos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RedesSociais_Palestrantes_palestranteId",
                        column: x => x.palestranteId,
                        principalTable: "Palestrantes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lotes_eventoId",
                table: "Lotes",
                column: "eventoId");

            migrationBuilder.CreateIndex(
                name: "IX_PalestrantesEventos_palestranteId",
                table: "PalestrantesEventos",
                column: "palestranteId");

            migrationBuilder.CreateIndex(
                name: "IX_RedesSociais_eventoId",
                table: "RedesSociais",
                column: "eventoId");

            migrationBuilder.CreateIndex(
                name: "IX_RedesSociais_palestranteId",
                table: "RedesSociais",
                column: "palestranteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lotes");

            migrationBuilder.DropTable(
                name: "PalestrantesEventos");

            migrationBuilder.DropTable(
                name: "RedesSociais");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Palestrantes");
        }
    }
}
