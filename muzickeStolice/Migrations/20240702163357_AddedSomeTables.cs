using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace muzickeStolice.Migrations
{
    /// <inheritdoc />
    public partial class AddedSomeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bendovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naziv = table.Column<string>(type: "text", nullable: false),
                    Opis = table.Column<string>(type: "text", nullable: false),
                    DatumOsnivanja = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bendovi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zanrovi",
                columns: table => new
                {
                    Naziv = table.Column<string>(type: "text", nullable: false),
                    Opis = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zanrovi", x => x.Naziv);
                });

            migrationBuilder.CreateTable(
                name: "MuzickaDela",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Naziv = table.Column<string>(type: "text", nullable: false),
                    ZanrDelaNaziv = table.Column<string>(type: "text", nullable: true),
                    Opis = table.Column<string>(type: "text", nullable: false),
                    Tip = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuzickaDela", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MuzickaDela_Zanrovi_ZanrDelaNaziv",
                        column: x => x.ZanrDelaNaziv,
                        principalTable: "Zanrovi",
                        principalColumn: "Naziv");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MuzickaDela_ZanrDelaNaziv",
                table: "MuzickaDela",
                column: "ZanrDelaNaziv");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bendovi");

            migrationBuilder.DropTable(
                name: "MuzickaDela");

            migrationBuilder.DropTable(
                name: "Zanrovi");
        }
    }
}
