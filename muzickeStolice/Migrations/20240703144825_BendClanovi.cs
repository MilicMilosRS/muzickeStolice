using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace muzickeStolice.Migrations
{
    /// <inheritdoc />
    public partial class BendClanovi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BendId",
                table: "Osobe",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Osobe_BendId",
                table: "Osobe",
                column: "BendId");

            migrationBuilder.AddForeignKey(
                name: "FK_Osobe_Bendovi_BendId",
                table: "Osobe",
                column: "BendId",
                principalTable: "Bendovi",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Osobe_Bendovi_BendId",
                table: "Osobe");

            migrationBuilder.DropIndex(
                name: "IX_Osobe_BendId",
                table: "Osobe");

            migrationBuilder.DropColumn(
                name: "BendId",
                table: "Osobe");
        }
    }
}
