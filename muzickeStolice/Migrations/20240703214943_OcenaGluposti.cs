using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace muzickeStolice.Migrations
{
    /// <inheritdoc />
    public partial class OcenaGluposti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ocene_autorEmail",
                table: "Ocene",
                column: "autorEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocene_Korisnici_autorEmail",
                table: "Ocene",
                column: "autorEmail",
                principalTable: "Korisnici",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocene_Ocenljivosti_primalacId",
                table: "Ocene",
                column: "primalacId",
                principalTable: "Ocenljivosti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocene_Korisnici_autorEmail",
                table: "Ocene");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocene_Ocenljivosti_primalacId",
                table: "Ocene");

            migrationBuilder.DropIndex(
                name: "IX_Ocene_autorEmail",
                table: "Ocene");
        }
    }
}
