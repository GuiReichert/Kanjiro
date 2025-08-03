using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kanjiro.API.Migrations
{
    /// <inheritdoc />
    public partial class Adding_CardInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Back",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Front",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "InfoId",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewSchedule",
                table: "Cards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CardInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Front = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Back = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_InfoId",
                table: "Cards",
                column: "InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_CardInfos_InfoId",
                table: "Cards",
                column: "InfoId",
                principalTable: "CardInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_CardInfos_InfoId",
                table: "Cards");

            migrationBuilder.DropTable(
                name: "CardInfos");

            migrationBuilder.DropIndex(
                name: "IX_Cards_InfoId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "InfoId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ReviewSchedule",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Cards");

            migrationBuilder.AddColumn<string>(
                name: "Back",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Front",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
