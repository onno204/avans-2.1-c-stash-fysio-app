using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddedDevUser1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AdditionalIdentifier", "BirthDate", "DcsphCode", "DcsphDescription", "Email", "EndDateTreatment", "FullName", "Gender", "GlobalDescriptionComplaints", "IntakeSuperVisionUserUserId", "IntakeUserUserId", "MainTherapistUserId", "Password", "Picture", "SignUpDate", "TreatmentPlan", "UserType" },
                values: new object[] { 1, 2167988, new DateTime(2002, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 999, "unknown", "o.vanhelfteren@student.avans.nl", new DateTime(2021, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Onno van Helfteren", 0, "Heel veel klachten", null, null, null, null, null, new DateTime(2021, 10, 26, 4, 19, 55, 133, DateTimeKind.Local).AddTicks(3150), "Geen", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
