using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace muzickeStolice.Migrations
{
    /// <inheritdoc />
    public partial class SlikeOpetOpet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string[]>(
                name: "slikeLinkovi",
                table: "MuzickaDela",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "slikeLinkovi",
                table: "MuzickaDela");
        }
    }
}
