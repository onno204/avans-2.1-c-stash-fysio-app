using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "SignUpDate",
                value: new DateTime(2022, 1, 23, 19, 26, 16, 625, DateTimeKind.Local).AddTicks(8734));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AdditionalIdentifier", "BirthDate", "DcsphCode", "DcsphDescription", "Email", "EndDateTreatment", "FullName", "Gender", "GlobalDescriptionComplaints", "IntakeSuperVisionUserId", "IntakeUserId", "MainTherapistId", "Password", "Picture", "SignUpDate", "TreatmentPlan", "UserType" },
                values: new object[] { 100000, 2167989, new DateTime(2002, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 999, "unknown", "o.thrapist@student.avans.nl", new DateTime(2021, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Onno thrapist", 0, "Heel veel klachten", null, null, null, null, null, new DateTime(2022, 1, 23, 19, 26, 16, 626, DateTimeKind.Local).AddTicks(7296), "Geen", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 100000);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "SignUpDate",
                value: new DateTime(2022, 1, 23, 5, 3, 4, 570, DateTimeKind.Local).AddTicks(5393));
        }
    }
}
