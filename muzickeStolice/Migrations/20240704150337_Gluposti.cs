using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace muzickeStolice.Migrations
{
    /// <inheritdoc />
    public partial class Gluposti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Glasovi",
                columns: table => new
                {
                    KorisnikEmail = table.Column<string>(type: "text", nullable: false),
                    AlbumId = table.Column<int>(type: "integer", nullable: false),
                    Godina = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glasovi", x => new { x.KorisnikEmail, x.AlbumId, x.Godina });
                    table.ForeignKey(
                        name: "FK_Glasovi_Korisnici_KorisnikEmail",
                        column: x => x.KorisnikEmail,
                        principalTable: "Korisnici",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Glasovi_MuzickaDela_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "MuzickaDela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Glasovi_AlbumId",
                table: "Glasovi",
                column: "AlbumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Glasovi");
        }
    }
}
