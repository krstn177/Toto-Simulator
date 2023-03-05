using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Toto_Simulator.Data.Migrations
{
    public partial class InitNumbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Number_Draws_DrawId",
                table: "Number");

            migrationBuilder.DropForeignKey(
                name: "FK_Number_Tickets_TicketId",
                table: "Number");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Number",
                table: "Number");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Number",
                newName: "Numbers");

            migrationBuilder.RenameIndex(
                name: "IX_Number_TicketId",
                table: "Numbers",
                newName: "IX_Numbers_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Number_DrawId",
                table: "Numbers",
                newName: "IX_Numbers_DrawId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Earnings",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ocurrences",
                table: "Numbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Numbers",
                table: "Numbers",
                column: "Id");

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
                column: "Date",
                value: new DateTime(2023, 2, 1, 19, 35, 55, 775, DateTimeKind.Local).AddTicks(2783));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_Draws_DrawId",
                table: "Numbers");

            migrationBuilder.DropForeignKey(
                name: "FK_Numbers_Tickets_TicketId",
                table: "Numbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Numbers",
                table: "Numbers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "userId1");

            migrationBuilder.DropColumn(
                name: "Ocurrences",
                table: "Numbers");

            migrationBuilder.RenameTable(
                name: "Numbers",
                newName: "Number");

            migrationBuilder.RenameIndex(
                name: "IX_Numbers_TicketId",
                table: "Number",
                newName: "IX_Number_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Numbers_DrawId",
                table: "Number",
                newName: "IX_Number_DrawId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<decimal>(
                name: "Earnings",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Number",
                table: "Number",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Earnings", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "userId1", 0, "d71f41e4-836b-4efa-9cd0-54d8ba897bf8", "User", 0m, "guest@mail.com", false, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEEbx3cxOAA67KZhEg5E2YJvkmOpUw6Dz9npMi9ne3VzdAt0W/+uclWpEFF7KN2DyGg==", null, false, "55cf9838-0a94-4501-a6e1-029b3511b7d1", false, "guest" });

            migrationBuilder.UpdateData(
                table: "Draws",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 1, 26, 18, 14, 21, 643, DateTimeKind.Local).AddTicks(6813));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2023, 2, 26, 18, 14, 21, 643, DateTimeKind.Local).AddTicks(6924));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2023, 2, 26, 18, 14, 21, 643, DateTimeKind.Local).AddTicks(6931));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2023, 2, 26, 18, 14, 21, 643, DateTimeKind.Local).AddTicks(6935));

            migrationBuilder.AddForeignKey(
                name: "FK_Number_Draws_DrawId",
                table: "Number",
                column: "DrawId",
                principalTable: "Draws",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Number_Tickets_TicketId",
                table: "Number",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id");
        }
    }
}
