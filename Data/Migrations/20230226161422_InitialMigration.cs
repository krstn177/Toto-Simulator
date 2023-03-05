using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Toto_Simulator.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Earnings",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Draws",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fund = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstGroupWinners = table.Column<int>(type: "int", nullable: false),
                    FirstGroupSum = table.Column<float>(type: "real", nullable: false),
                    SecondGroupWinners = table.Column<int>(type: "int", nullable: false),
                    SecondGroupSum = table.Column<float>(type: "real", nullable: false),
                    ThirdGroupWinners = table.Column<int>(type: "int", nullable: false),
                    ThirdGroupSum = table.Column<float>(type: "real", nullable: false),
                    FourthGroupWinners = table.Column<int>(type: "int", nullable: false),
                    FourthGroupSum = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draws", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jackpots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccumulatedSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jackpots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrawId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Draws_DrawId",
                        column: x => x.DrawId,
                        principalTable: "Draws",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Number",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    DrawId = table.Column<int>(type: "int", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Number", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Number_Draws_DrawId",
                        column: x => x.DrawId,
                        principalTable: "Draws",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Number_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Earnings", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "userId1", 0, "d71f41e4-836b-4efa-9cd0-54d8ba897bf8", "User", 0m, "guest@mail.com", false, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEEbx3cxOAA67KZhEg5E2YJvkmOpUw6Dz9npMi9ne3VzdAt0W/+uclWpEFF7KN2DyGg==", null, false, "55cf9838-0a94-4501-a6e1-029b3511b7d1", false, "guest" });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "Date", "FirstGroupSum", "FirstGroupWinners", "FourthGroupSum", "FourthGroupWinners", "Fund", "SecondGroupSum", "SecondGroupWinners", "ThirdGroupSum", "ThirdGroupWinners" },
                values: new object[] { 1, new DateTime(2023, 1, 26, 18, 14, 21, 643, DateTimeKind.Local).AddTicks(6813), 0f, 0, 0f, 0, 100000000m, 0f, 0, 0f, 0 });

            migrationBuilder.InsertData(
                table: "Jackpots",
                columns: new[] { "Id", "AccumulatedSum" },
                values: new object[] { 1, 10000m });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Date", "DrawId", "OwnerId", "Price" },
                values: new object[] { 1, new DateTime(2023, 2, 26, 18, 14, 21, 643, DateTimeKind.Local).AddTicks(6924), 1, "userId1", 0m });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Date", "DrawId", "OwnerId", "Price" },
                values: new object[] { 2, new DateTime(2023, 2, 26, 18, 14, 21, 643, DateTimeKind.Local).AddTicks(6931), 1, "userId1", 0m });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Date", "DrawId", "OwnerId", "Price" },
                values: new object[] { 3, new DateTime(2023, 2, 26, 18, 14, 21, 643, DateTimeKind.Local).AddTicks(6935), 1, "userId1", 0m });

            migrationBuilder.CreateIndex(
                name: "IX_Number_DrawId",
                table: "Number",
                column: "DrawId");

            migrationBuilder.CreateIndex(
                name: "IX_Number_TicketId",
                table: "Number",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DrawId",
                table: "Tickets",
                column: "DrawId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OwnerId",
                table: "Tickets",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jackpots");

            migrationBuilder.DropTable(
                name: "Number");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Draws");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "userId1");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Earnings",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
