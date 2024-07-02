using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace muzickeStolice.Migrations
{
    /// <inheritdoc />
    public partial class ChangedInterface : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "MuzickaDela",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Bendovi",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "IzvodjacID",
                table: "Osobe",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OcenljivoID",
                table: "MuzickaDela",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IzvodjacID",
                table: "Bendovi",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Izvodjac",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MuzickoDeloId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izvodjac", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Izvodjac_MuzickaDela_MuzickoDeloId",
                        column: x => x.MuzickoDeloId,
                        principalTable: "MuzickaDela",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ocenljivo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocenljivo", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Osobe_IzvodjacID",
                table: "Osobe",
                column: "IzvodjacID");

            migrationBuilder.CreateIndex(
                name: "IX_MuzickaDela_OcenljivoID",
                table: "MuzickaDela",
                column: "OcenljivoID");

            migrationBuilder.CreateIndex(
                name: "IX_Bendovi_IzvodjacID",
                table: "Bendovi",
                column: "IzvodjacID");

            migrationBuilder.CreateIndex(
                name: "IX_Izvodjac_MuzickoDeloId",
                table: "Izvodjac",
                column: "MuzickoDeloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bendovi_Izvodjac_IzvodjacID",
                table: "Bendovi",
                column: "IzvodjacID",
                principalTable: "Izvodjac",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bendovi_Izvodjac_IzvodjacID",
                table: "Bendovi");

            migrationBuilder.DropForeignKey(
                name: "FK_MuzickaDela_Ocenljivo_OcenljivoID",
                table: "MuzickaDela");

            migrationBuilder.DropForeignKey(
                name: "FK_Osobe_Izvodjac_IzvodjacID",
                table: "Osobe");

            migrationBuilder.DropTable(
                name: "Izvodjac");

            migrationBuilder.DropTable(
                name: "Ocenljivo");

            migrationBuilder.DropIndex(
                name: "IX_Osobe_IzvodjacID",
                table: "Osobe");

            migrationBuilder.DropIndex(
                name: "IX_MuzickaDela_OcenljivoID",
                table: "MuzickaDela");

            migrationBuilder.DropIndex(
                name: "IX_Bendovi_IzvodjacID",
                table: "Bendovi");

            migrationBuilder.DropColumn(
                name: "IzvodjacID",
                table: "Osobe");

            migrationBuilder.DropColumn(
                name: "OcenljivoID",
                table: "MuzickaDela");

            migrationBuilder.DropColumn(
                name: "IzvodjacID",
                table: "Bendovi");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MuzickaDela",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bendovi",
                newName: "ID");
        }
    }
}
