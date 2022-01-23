using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Sessions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "SessionDuration",
                table: "Users",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "SessionsPerWeek",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "SignUpDate",
                value: new DateTime(2022, 1, 23, 20, 53, 30, 94, DateTimeKind.Local).AddTicks(8491));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 100000,
                column: "SignUpDate",
                value: new DateTime(2022, 1, 23, 20, 53, 30, 95, DateTimeKind.Local).AddTicks(6505));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionDuration",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SessionsPerWeek",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "SignUpDate",
                value: new DateTime(2022, 1, 23, 19, 26, 16, 625, DateTimeKind.Local).AddTicks(8734));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 100000,
                column: "SignUpDate",
                value: new DateTime(2022, 1, 23, 19, 26, 16, 626, DateTimeKind.Local).AddTicks(7296));
        }
    }
}
