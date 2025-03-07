using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelefonBozorNavoiBot.Dal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    BotUserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelegramUserId = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.BotUserId);
                });

            migrationBuilder.CreateTable(
                name: "Announcement",
                columns: table => new
                {
                    AnnouncementId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhoneModel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BatteryCapacity = table.Column<int>(type: "int", nullable: false),
                    BatteryHealth = table.Column<int>(type: "int", nullable: false),
                    RAM = table.Column<int>(type: "int", nullable: false),
                    Storage = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BotUserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcement", x => x.AnnouncementId);
                    table.ForeignKey(
                        name: "FK_Announcement_User_BotUserId",
                        column: x => x.BotUserId,
                        principalTable: "User",
                        principalColumn: "BotUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcement_BotUserId",
                table: "Announcement",
                column: "BotUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcement");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
