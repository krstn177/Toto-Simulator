using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Toto_Simulator.Data.Migrations
{
    public partial class jackpotValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "userId1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4804c902-b75e-4023-a14f-942e752b45cb", "AQAAAAEAACcQAAAAEJeVBJu7Xv5M2GUCZPufFgAIw2zzYmFsxoPBafV83kKGKCqrjNLd2V5Vju5sJv8G8g==", "76eaa14b-0e43-4774-91fe-190ba834d5ac" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "userId1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ea093b6-9547-4b2e-ad2e-d7118670a523", "AQAAAAEAACcQAAAAEEgDcvNU1BF0PKwr1A7qC5AQN/bkZqAN4Z/ZR0FrHR2BiioXHQiXNGhcneu9Cd0mPA==", "5f89792d-6f75-4d46-8253-82353724c8c6" });
        }
    }
}
