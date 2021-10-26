using System;
using System.Collections.Generic;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    AdditionalIdentifier = 2167988, Appointments = new List<Appointment>(), BirthDate = new DateTime(2002, 02, 04), Comments = new List<Comment>(), DcsphCode = 999, DcsphDescription = "unknown", Email = "o.vanhelfteren@student.avans.nl",
                    EndDateTreatment = new DateTime(2021, 10, 30), FullName = "Onno van Helfteren", Gender = Gender.Male, GlobalDescriptionComplaints = "Heel veel klachten", IntakeSuperVisionUser = null, IntakeUser = null, MainTherapist = null, Password = null,
                    Picture = null, SignUpDate = DateTime.Now, TreatmentHistory = new List<Treatment>(), TreatmentPlan = "Geen", UserId = 1, UserType = UserType.Therapist
                });

            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasOne<User>(u => u.IntakeUser);
            modelBuilder.Entity<User>().HasOne<User>(u => u.MainTherapist);
            modelBuilder.Entity<User>().HasOne<User>(u => u.IntakeSuperVisionUser);
            modelBuilder.Entity<User>().OwnsMany<Appointment>(u => u.Appointments, a =>
            {
                a.HasOne<User>(a2 => a2.AppointmentUser).WithMany().OnDelete(DeleteBehavior.NoAction);
                a.HasOne<User>(a2 => a2.AppointmentWithUser).WithMany().OnDelete(DeleteBehavior.NoAction);
                a.HasOne<User>(a2 => a2.AppointmentCreatedByUser).WithMany().OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<User>().OwnsMany<Comment>(u => u.Comments, c =>
            {
                c.HasOne<User>(c2 => c2.CommentUser).WithMany().OnDelete(DeleteBehavior.NoAction);
                c.HasOne<User>(c2 => c2.CommentMadeBy).WithMany().OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<User>().OwnsMany<Treatment>(u => u.TreatmentHistory, t =>
            {
                t.HasOne<User>(t2 => t2.TreatmentUser).WithMany().OnDelete(DeleteBehavior.NoAction);
                t.HasOne<User>(t2 => t2.CarriedOutByUser).WithMany().OnDelete(DeleteBehavior.NoAction);
            });


        }
    }
}
