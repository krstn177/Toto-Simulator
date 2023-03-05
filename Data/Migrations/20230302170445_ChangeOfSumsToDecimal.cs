using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Toto_Simulator.Data.Migrations
{
    public partial class ChangeOfSumsToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ThirdGroupSum",
                table: "Draws",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "SecondGroupSum",
                table: "Draws",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "FourthGroupSum",
                table: "Draws",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "FirstGroupSum",
                table: "Draws",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

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
                columns: new[] { "Date", "FirstGroupSum", "FourthGroupSum", "SecondGroupSum", "ThirdGroupSum" },
                values: new object[] { new DateTime(2023, 2, 2, 19, 4, 44, 644, DateTimeKind.Local).AddTicks(5589), 0m, 0m, 0m, 0m });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ThirdGroupSum",
                table: "Draws",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "SecondGroupSum",
                table: "Draws",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "FourthGroupSum",
                table: "Draws",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "FirstGroupSum",
                table: "Draws",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "userId1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4100957d-a7a0-4028-b79f-94e1b362bd10", "AQAAAAEAACcQAAAAENveq7q3RoVu1vl7b2zAEGwpQ5BOFw0QqxSeN/5waHk4+dTEVPrNLOsyN9IzOO+jvg==", "de275f80-97ff-4ad4-af29-52e89d2ba088" });

            migrationBuilder.UpdateData(
                table: "Draws",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "FirstGroupSum", "FourthGroupSum", "SecondGroupSum", "ThirdGroupSum" },
                values: new object[] { new DateTime(2023, 2, 1, 19, 35, 55, 775, DateTimeKind.Local).AddTicks(2783), 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 3, 1, 19, 35, 55, 775, DateTimeKind.Local).AddTicks(2900));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 3, 1, 19, 35, 55, 775, DateTimeKind.Local).AddTicks(2906));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 3, 1, 19, 35, 55, 775, DateTimeKind.Local).AddTicks(2910));
        }
    }
}
