using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Toto_Simulator.Data.Migrations
{
    public partial class NamesSetAvailable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jackpots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Draws",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "userId1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ea093b6-9547-4b2e-ad2e-d7118670a523", "AQAAAAEAACcQAAAAEEgDcvNU1BF0PKwr1A7qC5AQN/bkZqAN4Z/ZR0FrHR2BiioXHQiXNGhcneu9Cd0mPA==", "5f89792d-6f75-4d46-8253-82353724c8c6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "userId1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d6d4e88-fef3-48bc-804e-04069f3a1bc7", "AQAAAAEAACcQAAAAEIL2ZsL6Wug3bVL0ODgnBTDF01kMQwdwQ085xCOSTuNcAtATOwWVNjyeGfpRtfNQWA==", "da5e784c-104b-41ca-b8dd-17c9cbb3d494" });

            migrationBuilder.InsertData(
                table: "Draws",
                columns: new[] { "Id", "Date", "FirstGroupSum", "FirstGroupWinners", "FourthGroupSum", "FourthGroupWinners", "Fund", "SecondGroupSum", "SecondGroupWinners", "ThirdGroupSum", "ThirdGroupWinners" },
                values: new object[] { 1, new DateTime(2023, 2, 5, 18, 25, 27, 981, DateTimeKind.Local).AddTicks(9144), 0m, 0, 0m, 0, 100000000m, 0m, 0, 0m, 0 });

            migrationBuilder.InsertData(
                table: "Jackpots",
                columns: new[] { "Id", "AccumulatedSum" },
                values: new object[] { 1, 10000m });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Date", "DrawId", "IsInFirstGroup", "IsInFourthGroup", "IsInSecondGroup", "IsInThirdGroup", "OwnerId", "Price" },
                values: new object[] { 1, new DateTime(2023, 3, 5, 18, 25, 27, 981, DateTimeKind.Local).AddTicks(9228), 1, false, false, false, false, "userId1", 0m });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Date", "DrawId", "IsInFirstGroup", "IsInFourthGroup", "IsInSecondGroup", "IsInThirdGroup", "OwnerId", "Price" },
                values: new object[] { 2, new DateTime(2023, 3, 5, 18, 25, 27, 981, DateTimeKind.Local).AddTicks(9233), 1, false, false, false, false, "userId1", 0m });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Date", "DrawId", "IsInFirstGroup", "IsInFourthGroup", "IsInSecondGroup", "IsInThirdGroup", "OwnerId", "Price" },
                values: new object[] { 3, new DateTime(2023, 3, 5, 18, 25, 27, 981, DateTimeKind.Local).AddTicks(9237), 1, false, false, false, false, "userId1", 0m });
        }
    }
}
