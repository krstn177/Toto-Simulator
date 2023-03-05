using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Toto_Simulator.Data.Migrations
{
    public partial class ListOfTicketsChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "userId1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d6d4e88-fef3-48bc-804e-04069f3a1bc7", "AQAAAAEAACcQAAAAEIL2ZsL6Wug3bVL0ODgnBTDF01kMQwdwQ085xCOSTuNcAtATOwWVNjyeGfpRtfNQWA==", "da5e784c-104b-41ca-b8dd-17c9cbb3d494" });

            migrationBuilder.UpdateData(
                table: "Draws",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 2, 5, 18, 25, 27, 981, DateTimeKind.Local).AddTicks(9144));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 3, 5, 18, 25, 27, 981, DateTimeKind.Local).AddTicks(9228));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 3, 5, 18, 25, 27, 981, DateTimeKind.Local).AddTicks(9233));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 3, 5, 18, 25, 27, 981, DateTimeKind.Local).AddTicks(9237));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
