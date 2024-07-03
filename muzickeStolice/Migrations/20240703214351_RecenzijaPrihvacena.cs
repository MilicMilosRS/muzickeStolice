using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace muzickeStolice.Migrations
{
    /// <inheritdoc />
    public partial class RecenzijaPrihvacena : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Prihvacena",
                table: "Recenzije",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prihvacena",
                table: "Recenzije");
        }
    }
}
