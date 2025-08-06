using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kanjiro.API.Migrations
{
    /// <inheritdoc />
    public partial class Adding_Counters_To_CardModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReviewSchedule",
                table: "Cards",
                newName: "NextReviewDate");

            migrationBuilder.AddColumn<float>(
                name: "CurrentDifficultyMultiplier",
                table: "Cards",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "MistakeCounter",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewDateCounter",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentDifficultyMultiplier",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "MistakeCounter",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ReviewDateCounter",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "NextReviewDate",
                table: "Cards",
                newName: "ReviewSchedule");
        }
    }
}
