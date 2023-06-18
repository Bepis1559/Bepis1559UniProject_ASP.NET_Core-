using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniProject.Migrations
{
    /// <inheritdoc />
    public partial class AddingTypeToTrackers4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "SquatTrackers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "DeadliftTrackers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "BenchTrackers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "SquatTrackers");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "DeadliftTrackers");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "BenchTrackers");
        }
    }
}
