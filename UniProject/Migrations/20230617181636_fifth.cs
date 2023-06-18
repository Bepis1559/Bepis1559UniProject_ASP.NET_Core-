using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniProject.Migrations
{
    /// <inheritdoc />
    public partial class fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgressTrackings");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BenchTrackers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DeadliftTrackers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BodyWeight = table.Column<float>(type: "real", nullable: true),
                    LiftedWeight = table.Column<float>(type: "real", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeadliftTrackers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeadliftTrackers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SquatTrackers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BodyWeight = table.Column<float>(type: "real", nullable: true),
                    LiftedWeight = table.Column<float>(type: "real", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SquatTrackers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SquatTrackers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BenchTrackers_UserId",
                table: "BenchTrackers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeadliftTrackers_UserId",
                table: "DeadliftTrackers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SquatTrackers_UserId",
                table: "SquatTrackers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BenchTrackers_AspNetUsers_UserId",
                table: "BenchTrackers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BenchTrackers_AspNetUsers_UserId",
                table: "BenchTrackers");

            migrationBuilder.DropTable(
                name: "DeadliftTrackers");

            migrationBuilder.DropTable(
                name: "SquatTrackers");

            migrationBuilder.DropIndex(
                name: "IX_BenchTrackers_UserId",
                table: "BenchTrackers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BenchTrackers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProgressTrackings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Bench = table.Column<float>(type: "real", nullable: true),
                    BodyWeight = table.Column<float>(type: "real", nullable: true),
                    Deadlift = table.Column<float>(type: "real", nullable: true),
                    Squat = table.Column<float>(type: "real", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressTrackings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgressTrackings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgressTrackings_UserId",
                table: "ProgressTrackings",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}
