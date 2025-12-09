using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kanjiro.API.Migrations
{
    /// <inheritdoc />
    public partial class Adding_Romaji_Reading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RomajiReading",
                table: "CardInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RomajiReading",
                table: "CardInfos");
        }
    }
}
