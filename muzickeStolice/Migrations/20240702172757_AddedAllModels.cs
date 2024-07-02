using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace muzickeStolice.Migrations
{
    /// <inheritdoc />
    public partial class AddedAllModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bendovi_Izvodjac_IzvodjacID",
                table: "Bendovi");

            migrationBuilder.DropForeignKey(
                name: "FK_Izvodjac_MuzickaDela_MuzickoDeloId",
                table: "Izvodjac");

            migrationBuilder.DropForeignKey(
                name: "FK_MuzickaDela_Ocenljivo_OcenljivoID",
                table: "MuzickaDela");

            migrationBuilder.DropForeignKey(
                name: "FK_Osobe_Izvodjac_IzvodjacID",
                table: "Osobe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ocenljivo",
                table: "Ocenljivo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Izvodjac",
                table: "Izvodjac");

            migrationBuilder.RenameTable(
                name: "Ocenljivo",
                newName: "Ocenljivosti");

            migrationBuilder.RenameTable(
                name: "Izvodjac",
                newName: "Izvodjaci");

            migrationBuilder.RenameIndex(
                name: "IX_Izvodjac_MuzickoDeloId",
                table: "Izvodjaci",
                newName: "IX_Izvodjaci_MuzickoDeloId");

            migrationBuilder.AddColumn<int>(
                name: "PlejlistaID",
                table: "MuzickaDela",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IzvodjenjeId",
                table: "Izvodjaci",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ocenljivosti",
                table: "Ocenljivosti",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Izvodjaci",
                table: "Izvodjaci",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Izdanja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OcenljivoID = table.Column<int>(type: "integer", nullable: false),
                    DeloID = table.Column<int>(type: "integer", nullable: false),
                    Tip = table.Column<int>(type: "integer", nullable: false),
                    DatumIzdanja = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izdanja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Izdanja_Ocenljivosti_OcenljivoID",
                        column: x => x.OcenljivoID,
                        principalTable: "Ocenljivosti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IzdanjaIzvodjenja",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IzvodjenjeID = table.Column<int>(type: "integer", nullable: false),
                    Opis = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzdanjaIzvodjenja", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Izvodjenja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OcenljivoID = table.Column<int>(type: "integer", nullable: false),
                    DeloID = table.Column<int>(type: "integer", nullable: false),
                    Datum = table.Column<DateOnly>(type: "date", nullable: false),
                    Opis = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izvodjenja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Izvodjenja_Ocenljivosti_OcenljivoID",
                        column: x => x.OcenljivoID,
                        principalTable: "Ocenljivosti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Email = table.Column<string>(type: "text", nullable: false),
                    Lozinka = table.Column<string>(type: "text", nullable: false),
                    Tip = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Ocene",
                columns: table => new
                {
                    primalacId = table.Column<int>(type: "integer", nullable: false),
                    autorEmail = table.Column<string>(type: "text", nullable: false),
                    Vrednost = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocene", x => new { x.primalacId, x.autorEmail });
                });

            migrationBuilder.CreateTable(
                name: "Plejliste",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ZanrNaziv = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plejliste", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Plejliste_Zanrovi_ZanrNaziv",
                        column: x => x.ZanrNaziv,
                        principalTable: "Zanrovi",
                        principalColumn: "Naziv");
                });

            migrationBuilder.CreateTable(
                name: "Profili",
                columns: table => new
                {
                    korisnikEmail = table.Column<string>(type: "text", nullable: false),
                    Ime = table.Column<string>(type: "text", nullable: false),
                    Prezime = table.Column<string>(type: "text", nullable: false),
                    PrikaziRecenzije = table.Column<bool>(type: "boolean", nullable: false),
                    PrikaziOcene = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profili", x => x.korisnikEmail);
                });

            migrationBuilder.CreateTable(
                name: "Recenzije",
                columns: table => new
                {
                    primalacId = table.Column<int>(type: "integer", nullable: false),
                    autorEmail = table.Column<string>(type: "text", nullable: false),
                    Tekst = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzije", x => new { x.primalacId, x.autorEmail });
                });

            migrationBuilder.CreateIndex(
                name: "IX_MuzickaDela_PlejlistaID",
                table: "MuzickaDela",
                column: "PlejlistaID");

            migrationBuilder.CreateIndex(
                name: "IX_Izvodjaci_IzvodjenjeId",
                table: "Izvodjaci",
                column: "IzvodjenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Izdanja_OcenljivoID",
                table: "Izdanja",
                column: "OcenljivoID");

            migrationBuilder.CreateIndex(
                name: "IX_Izvodjenja_OcenljivoID",
                table: "Izvodjenja",
                column: "OcenljivoID");

            migrationBuilder.CreateIndex(
                name: "IX_Plejliste_ZanrNaziv",
                table: "Plejliste",
                column: "ZanrNaziv");

            migrationBuilder.AddForeignKey(
                name: "FK_Bendovi_Izvodjaci_IzvodjacID",
                table: "Bendovi",
                column: "IzvodjacID",
                principalTable: "Izvodjaci",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Izvodjaci_Izvodjenja_IzvodjenjeId",
                table: "Izvodjaci",
                column: "IzvodjenjeId",
                principalTable: "Izvodjenja",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Izvodjaci_MuzickaDela_MuzickoDeloId",
                table: "Izvodjaci",
                column: "MuzickoDeloId",
                principalTable: "MuzickaDela",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MuzickaDela_Ocenljivosti_OcenljivoID",
                table: "MuzickaDela",
                column: "OcenljivoID",
                principalTable: "Ocenljivosti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MuzickaDela_Plejliste_PlejlistaID",
                table: "MuzickaDela",
                column: "PlejlistaID",
                principalTable: "Plejliste",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Osobe_Izvodjaci_IzvodjacID",
                table: "Osobe",
                column: "IzvodjacID",
                principalTable: "Izvodjaci",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bendovi_Izvodjaci_IzvodjacID",
                table: "Bendovi");

            migrationBuilder.DropForeignKey(
                name: "FK_Izvodjaci_Izvodjenja_IzvodjenjeId",
                table: "Izvodjaci");

            migrationBuilder.DropForeignKey(
                name: "FK_Izvodjaci_MuzickaDela_MuzickoDeloId",
                table: "Izvodjaci");

            migrationBuilder.DropForeignKey(
                name: "FK_MuzickaDela_Ocenljivosti_OcenljivoID",
                table: "MuzickaDela");

            migrationBuilder.DropForeignKey(
                name: "FK_MuzickaDela_Plejliste_PlejlistaID",
                table: "MuzickaDela");

            migrationBuilder.DropForeignKey(
                name: "FK_Osobe_Izvodjaci_IzvodjacID",
                table: "Osobe");

            migrationBuilder.DropTable(
                name: "Izdanja");

            migrationBuilder.DropTable(
                name: "IzdanjaIzvodjenja");

            migrationBuilder.DropTable(
                name: "Izvodjenja");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Ocene");

            migrationBuilder.DropTable(
                name: "Plejliste");

            migrationBuilder.DropTable(
                name: "Profili");

            migrationBuilder.DropTable(
                name: "Recenzije");

            migrationBuilder.DropIndex(
                name: "IX_MuzickaDela_PlejlistaID",
                table: "MuzickaDela");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ocenljivosti",
                table: "Ocenljivosti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Izvodjaci",
                table: "Izvodjaci");

            migrationBuilder.DropIndex(
                name: "IX_Izvodjaci_IzvodjenjeId",
                table: "Izvodjaci");

            migrationBuilder.DropColumn(
                name: "PlejlistaID",
                table: "MuzickaDela");

            migrationBuilder.DropColumn(
                name: "IzvodjenjeId",
                table: "Izvodjaci");

            migrationBuilder.RenameTable(
                name: "Ocenljivosti",
                newName: "Ocenljivo");

            migrationBuilder.RenameTable(
                name: "Izvodjaci",
                newName: "Izvodjac");

            migrationBuilder.RenameIndex(
                name: "IX_Izvodjaci_MuzickoDeloId",
                table: "Izvodjac",
                newName: "IX_Izvodjac_MuzickoDeloId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ocenljivo",
                table: "Ocenljivo",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Izvodjac",
                table: "Izvodjac",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bendovi_Izvodjac_IzvodjacID",
                table: "Bendovi",
                column: "IzvodjacID",
                principalTable: "Izvodjac",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Izvodjac_MuzickaDela_MuzickoDeloId",
                table: "Izvodjac",
                column: "MuzickoDeloId",
                principalTable: "MuzickaDela",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MuzickaDela_Ocenljivo_OcenljivoID",
                table: "MuzickaDela",
                column: "OcenljivoID",
                principalTable: "Ocenljivo",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Osobe_Izvodjac_IzvodjacID",
                table: "Osobe",
                column: "IzvodjacID",
                principalTable: "Izvodjac",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
