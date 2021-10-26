using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    AdditionalIdentifier = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    EndDateTreatment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SignUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntakeUserUserId = table.Column<int>(type: "int", nullable: true),
                    IntakeSuperVisionUserUserId = table.Column<int>(type: "int", nullable: true),
                    MainTherapistUserId = table.Column<int>(type: "int", nullable: true),
                    DcsphCode = table.Column<int>(type: "int", nullable: false),
                    DcsphDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GlobalDescriptionComplaints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentPlan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Users_IntakeSuperVisionUserUserId",
                        column: x => x.IntakeSuperVisionUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_IntakeUserUserId",
                        column: x => x.IntakeUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_MainTherapistUserId",
                        column: x => x.MainTherapistUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentUserId = table.Column<int>(type: "int", nullable: false),
                    AppointmentWithUserId = table.Column<int>(type: "int", nullable: false),
                    AppointmentCreatedByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => new { x.UserId, x.AppointmentId });
                    table.ForeignKey(
                        name: "FK_Appointment_Users_AppointmentCreatedByUserId",
                        column: x => x.AppointmentCreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Appointment_Users_AppointmentUserId",
                        column: x => x.AppointmentUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Appointment_Users_AppointmentWithUserId",
                        column: x => x.AppointmentWithUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Appointment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentUserId = table.Column<int>(type: "int", nullable: false),
                    CommentMadeById = table.Column<int>(type: "int", nullable: false),
                    PubliclyVisible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => new { x.UserId, x.CommentId });
                    table.ForeignKey(
                        name: "FK_Comment_Users_CommentMadeById",
                        column: x => x.CommentMadeById,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Comment_Users_CommentUserId",
                        column: x => x.CommentUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Comment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    TreatmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    VektisId = table.Column<int>(type: "int", nullable: false),
                    VektisExplanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Room = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TreatmentUserId = table.Column<int>(type: "int", nullable: false),
                    CarriedOutByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => new { x.UserId, x.TreatmentId });
                    table.ForeignKey(
                        name: "FK_Treatment_Users_CarriedOutByUserId",
                        column: x => x.CarriedOutByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Treatment_Users_TreatmentUserId",
                        column: x => x.TreatmentUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Treatment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_AppointmentCreatedByUserId",
                table: "Appointment",
                column: "AppointmentCreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_AppointmentUserId",
                table: "Appointment",
                column: "AppointmentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_AppointmentWithUserId",
                table: "Appointment",
                column: "AppointmentWithUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CommentMadeById",
                table: "Comment",
                column: "CommentMadeById");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CommentUserId",
                table: "Comment",
                column: "CommentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_CarriedOutByUserId",
                table: "Treatment",
                column: "CarriedOutByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_TreatmentUserId",
                table: "Treatment",
                column: "TreatmentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IntakeSuperVisionUserUserId",
                table: "Users",
                column: "IntakeSuperVisionUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IntakeUserUserId",
                table: "Users",
                column: "IntakeUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MainTherapistUserId",
                table: "Users",
                column: "MainTherapistUserId");
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
