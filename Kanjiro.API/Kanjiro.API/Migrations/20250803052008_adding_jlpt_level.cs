using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kanjiro.API.Migrations
{
    /// <inheritdoc />
    public partial class adding_jlpt_level : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "CardInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "CardInfos");
        }
    }
}
