using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Toto_Simulator.Data.Migrations
{
    public partial class ManyToManyNumbersConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_Draws_DrawId",
                table: "Numbers");

            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_Tickets_TicketId",
                table: "Numbers");

            migrationBuilder.DropIndex(
                name: "IX_Numbers_DrawId",
                table: "Numbers");

            migrationBuilder.DropIndex(
                name: "IX_Numbers_TicketId",
                table: "Numbers");

            migrationBuilder.DropColumn(
                name: "DrawId",
                table: "Numbers");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Numbers");

            migrationBuilder.CreateTable(
                name: "DrawNumber",
                columns: table => new
                {
                    DrawsId = table.Column<int>(type: "int", nullable: false),
                    NumbersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrawNumber", x => new { x.DrawsId, x.NumbersId });
                    table.ForeignKey(
                        name: "FK_DrawNumber_Draws_DrawsId",
                        column: x => x.DrawsId,
                        principalTable: "Draws",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrawNumber_Numbers_NumbersId",
                        column: x => x.NumbersId,
                        principalTable: "Numbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NumberTicket",
                columns: table => new
                {
                    NumbersId = table.Column<int>(type: "int", nullable: false),
                    TicketsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberTicket", x => new { x.NumbersId, x.TicketsId });
                    table.ForeignKey(
                        name: "FK_NumberTicket_Numbers_NumbersId",
                        column: x => x.NumbersId,
                        principalTable: "Numbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NumberTicket_Tickets_TicketsId",
                        column: x => x.TicketsId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "userId1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca5f7a37-4eaf-4aba-a9fb-14c82ca0b166", "AQAAAAEAACcQAAAAEEm30cqs9AxAkxWIJVL/GKtReAbJQ3+P21j7/MVYrsgvQmhZrU0PEqHF+qJftSCJ1Q==", "ec5a63ad-0b87-4eb1-a16d-2e606fa820c7" });

            migrationBuilder.UpdateData(
                table: "Draws",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 2, 5, 17, 52, 26, 883, DateTimeKind.Local).AddTicks(2032));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 3, 5, 17, 52, 26, 883, DateTimeKind.Local).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 3, 5, 17, 52, 26, 883, DateTimeKind.Local).AddTicks(2121));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 3, 5, 17, 52, 26, 883, DateTimeKind.Local).AddTicks(2124));

            migrationBuilder.CreateIndex(
                name: "IX_DrawNumber_NumbersId",
                table: "DrawNumber",
                column: "NumbersId");

            migrationBuilder.CreateIndex(
                name: "IX_NumberTicket_TicketsId",
                table: "NumberTicket",
                column: "TicketsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrawNumber");

            migrationBuilder.DropTable(
                name: "NumberTicket");

            migrationBuilder.AddColumn<int>(
                name: "DrawId",
                table: "Numbers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Numbers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "userId1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "083f4a6f-344f-48d9-88ce-ba79daef3e73", "AQAAAAEAACcQAAAAEPt56PHct9dHs7dnaXBs6P5uup7RVu8+pCliobi7pH06+7npYIWyjAQ12z6VdtrmJg==", "c273d880-e2ed-4e48-9dfa-3f895a2f05b0" });

            migrationBuilder.UpdateData(
                table: "Draws",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 2, 2, 20, 8, 5, 589, DateTimeKind.Local).AddTicks(6484));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 3, 2, 20, 8, 5, 589, DateTimeKind.Local).AddTicks(6573));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 3, 2, 20, 8, 5, 589, DateTimeKind.Local).AddTicks(6580));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 3, 2, 20, 8, 5, 589, DateTimeKind.Local).AddTicks(6584));

            migrationBuilder.CreateIndex(
                name: "IX_Numbers_DrawId",
                table: "Numbers",
                column: "DrawId");

            migrationBuilder.CreateIndex(
                name: "IX_Numbers_TicketId",
                table: "Numbers",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_Draws_DrawId",
                table: "Numbers",
                column: "DrawId",
                principalTable: "Draws",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Numbers_Tickets_TicketId",
                table: "Numbers",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }
    }
}
