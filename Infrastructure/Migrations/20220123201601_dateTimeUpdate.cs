using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class dateTimeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Appointment",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Appointment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "SignUpDate",
                value: new DateTime(2022, 1, 23, 21, 16, 1, 25, DateTimeKind.Local).AddTicks(6125));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 100000,
                column: "SignUpDate",
                value: new DateTime(2022, 1, 23, 21, 16, 1, 26, DateTimeKind.Local).AddTicks(4116));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Appointment");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Appointment",
                newName: "Date");

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
    }
}
