using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace muzickeStolice.Migrations
{
    /// <inheritdoc />
    public partial class RecenzijaGluposti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OcenaautorEmail",
                table: "Recenzije",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OcenaprimalacId",
                table: "Recenzije",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Recenzije_OcenaprimalacId_OcenaautorEmail",
                table: "Recenzije",
                columns: new[] { "OcenaprimalacId", "OcenaautorEmail" });

            migrationBuilder.AddForeignKey(
                name: "FK_Recenzije_Ocene_OcenaprimalacId_OcenaautorEmail",
                table: "Recenzije",
                columns: new[] { "OcenaprimalacId", "OcenaautorEmail" },
                principalTable: "Ocene",
                principalColumns: new[] { "primalacId", "autorEmail" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recenzije_Ocene_OcenaprimalacId_OcenaautorEmail",
                table: "Recenzije");

            migrationBuilder.DropIndex(
                name: "IX_Recenzije_OcenaprimalacId_OcenaautorEmail",
                table: "Recenzije");

            migrationBuilder.DropColumn(
                name: "OcenaautorEmail",
                table: "Recenzije");

            migrationBuilder.DropColumn(
                name: "OcenaprimalacId",
                table: "Recenzije");
        }
    }
}
