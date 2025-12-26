using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kanjiro.API.Migrations
{
    /// <inheritdoc />
    public partial class Log_Date_And_Current_Deck_Id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentActiveDeckId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentActiveDeckId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Logs");
        }
    }
}
