using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    AdditionalIdentifier = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    EndDateTreatment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SignUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntakeUserId = table.Column<int>(type: "int", nullable: true),
                    IntakeSuperVisionUserId = table.Column<int>(type: "int", nullable: true),
                    MainTherapistId = table.Column<int>(type: "int", nullable: true),
                    DcsphCode = table.Column<int>(type: "int", nullable: false),
                    DcsphDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlobalDescriptionComplaints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentPlan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_IntakeSuperVisionUserId",
                        column: x => x.IntakeSuperVisionUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_IntakeUserId",
                        column: x => x.IntakeUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_MainTherapistId",
                        column: x => x.MainTherapistId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AppointmentWithUserId = table.Column<int>(type: "int", nullable: true),
                    AppointmentCreatedByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Users_AppointmentCreatedByUserId",
                        column: x => x.AppointmentCreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Users_AppointmentWithUserId",
                        column: x => x.AppointmentWithUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CommentMadeById = table.Column<int>(type: "int", nullable: true),
                    PubliclyVisible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Users_CommentMadeById",
                        column: x => x.CommentMadeById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VektisId = table.Column<int>(type: "int", nullable: false),
                    VektisExplanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Room = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CarriedOutByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatment_Users_CarriedOutByUserId",
                        column: x => x.CarriedOutByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Treatment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AdditionalIdentifier", "BirthDate", "DcsphCode", "DcsphDescription", "Email", "EndDateTreatment", "FullName", "Gender", "GlobalDescriptionComplaints", "IntakeSuperVisionUserId", "IntakeUserId", "MainTherapistId", "Password", "Picture", "SignUpDate", "TreatmentPlan", "UserType" },
                values: new object[] { 1, 2167988, new DateTime(2002, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 999, "unknown", "o.vanhelfteren@student.avans.nl", new DateTime(2021, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Onno van Helfteren", 0, "Heel veel klachten", null, null, null, null, null, new DateTime(2021, 10, 27, 1, 41, 24, 954, DateTimeKind.Local).AddTicks(4518), "Geen", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_AppointmentCreatedByUserId",
                table: "Appointment",
                column: "AppointmentCreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_AppointmentWithUserId",
                table: "Appointment",
                column: "AppointmentWithUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_UserId",
                table: "Appointment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CommentMadeById",
                table: "Comment",
                column: "CommentMadeById");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_CarriedOutByUserId",
                table: "Treatment",
                column: "CarriedOutByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_UserId",
                table: "Treatment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IntakeSuperVisionUserId",
                table: "Users",
                column: "IntakeSuperVisionUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IntakeUserId",
                table: "Users",
                column: "IntakeUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MainTherapistId",
                table: "Users",
                column: "MainTherapistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
