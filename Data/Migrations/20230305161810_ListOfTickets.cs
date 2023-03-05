using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Toto_Simulator.Data.Migrations
{
    public partial class ListOfTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "userId1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5e9c46d-df34-40ed-a230-4c4aa1200841", "AQAAAAEAACcQAAAAECo+acvS9g/gGsZ7vIPcNdURx7F/DxVG0H82iDBoEN3EqBZkE5UD+udMuoehCnWrbw==", "c5be755a-6534-484e-9698-cc9fc7e7f26e" });

            migrationBuilder.UpdateData(
                table: "Draws",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 2, 5, 18, 18, 9, 350, DateTimeKind.Local).AddTicks(5420));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 3, 5, 18, 18, 9, 350, DateTimeKind.Local).AddTicks(5505));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 3, 5, 18, 18, 9, 350, DateTimeKind.Local).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 3, 5, 18, 18, 9, 350, DateTimeKind.Local).AddTicks(5513));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
