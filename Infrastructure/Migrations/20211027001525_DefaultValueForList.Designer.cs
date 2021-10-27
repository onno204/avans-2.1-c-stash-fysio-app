﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20211027001525_DefaultValueForList")]
    partial class DefaultValueForList
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Domain.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AppointmentCreatedByUserId")
                        .HasColumnType("int");

                    b.Property<int?>("AppointmentWithUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentCreatedByUserId");

                    b.HasIndex("AppointmentWithUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("Core.Domain.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CommentMadeById")
                        .HasColumnType("int");

                    b.Property<string>("CommentText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("PubliclyVisible")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentMadeById");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Core.Domain.Treatment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarriedOutByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Room")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("VektisExplanation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VektisId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarriedOutByUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Treatment");
                });

            modelBuilder.Entity("Core.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdditionalIdentifier")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DcsphCode")
                        .HasColumnType("int");

                    b.Property<string>("DcsphDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDateTreatment")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("GlobalDescriptionComplaints")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IntakeSuperVisionUserId")
                        .HasColumnType("int");

                    b.Property<int?>("IntakeUserId")
                        .HasColumnType("int");

                    b.Property<int?>("MainTherapistId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SignUpDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TreatmentPlan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("IntakeSuperVisionUserId");

                    b.HasIndex("IntakeUserId");

                    b.HasIndex("MainTherapistId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdditionalIdentifier = 2167988,
                            BirthDate = new DateTime(2002, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DcsphCode = 999,
                            DcsphDescription = "unknown",
                            Email = "o.vanhelfteren@student.avans.nl",
                            EndDateTreatment = new DateTime(2021, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FullName = "Onno van Helfteren",
                            Gender = 0,
                            GlobalDescriptionComplaints = "Heel veel klachten",
                            SignUpDate = new DateTime(2021, 10, 27, 2, 15, 25, 164, DateTimeKind.Local).AddTicks(1000),
                            TreatmentPlan = "Geen",
                            UserType = 0
                        });
                });

            modelBuilder.Entity("Core.Domain.Appointment", b =>
                {
                    b.HasOne("Core.Domain.User", "AppointmentCreatedByUser")
                        .WithMany()
                        .HasForeignKey("AppointmentCreatedByUserId");

                    b.HasOne("Core.Domain.User", "AppointmentWithUser")
                        .WithMany()
                        .HasForeignKey("AppointmentWithUserId");

                    b.HasOne("Core.Domain.User", "User")
                        .WithMany("Appointments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppointmentCreatedByUser");

                    b.Navigation("AppointmentWithUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Domain.Comment", b =>
                {
                    b.HasOne("Core.Domain.User", "CommentMadeBy")
                        .WithMany()
                        .HasForeignKey("CommentMadeById");

                    b.HasOne("Core.Domain.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommentMadeBy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Domain.Treatment", b =>
                {
                    b.HasOne("Core.Domain.User", "CarriedOutByUser")
                        .WithMany()
                        .HasForeignKey("CarriedOutByUserId");

                    b.HasOne("Core.Domain.User", "User")
                        .WithMany("TreatmentHistory")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarriedOutByUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Domain.User", b =>
                {
                    b.HasOne("Core.Domain.User", "IntakeSuperVisionUser")
                        .WithMany()
                        .HasForeignKey("IntakeSuperVisionUserId");

                    b.HasOne("Core.Domain.User", "IntakeUser")
                        .WithMany()
                        .HasForeignKey("IntakeUserId");

                    b.HasOne("Core.Domain.User", "MainTherapist")
                        .WithMany()
                        .HasForeignKey("MainTherapistId");

                    b.Navigation("IntakeSuperVisionUser");

                    b.Navigation("IntakeUser");

                    b.Navigation("MainTherapist");
                });

            modelBuilder.Entity("Core.Domain.User", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Comments");

                    b.Navigation("TreatmentHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
