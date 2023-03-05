using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Toto_Simulator.Data.Migrations
{
    public partial class AddingChecksForTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInFirstGroup",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInFourthGroup",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInSecondGroup",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInThirdGroup",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInFirstGroup",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IsInFourthGroup",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IsInSecondGroup",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IsInThirdGroup",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "userId1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eabb2556-deb1-4dac-bccc-8adea7e1dd7e", "AQAAAAEAACcQAAAAECfWTQKsjp6y9C4TXVylODHcZ0p9BIIPs3rwwWa0EXUXMUHQPHlrzKGG+ng26tda3A==", "3110acd5-c846-4a6e-a778-a23177e4334c" });

            migrationBuilder.UpdateData(
                table: "Draws",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 2, 2, 19, 4, 44, 644, DateTimeKind.Local).AddTicks(5589));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 3, 2, 19, 4, 44, 644, DateTimeKind.Local).AddTicks(5695));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 3, 2, 19, 4, 44, 644, DateTimeKind.Local).AddTicks(5702));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 3, 2, 19, 4, 44, 644, DateTimeKind.Local).AddTicks(5706));
        }
    }
}
