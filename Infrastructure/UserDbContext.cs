using System;
using System.Collections.Generic;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Infrastructure
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Vektis> VektisList { get; set; }

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
                    Picture = null, SignUpDate = DateTime.Now, TreatmentHistory = new List<Treatment>(), TreatmentPlan = "Geen", Id = 1, UserType = UserType.Therapist
                });

            modelBuilder.Entity<User>().HasOne<User>(u => u.IntakeUser);
            modelBuilder.Entity<User>().HasOne<User>(u => u.MainTherapist);
            modelBuilder.Entity<User>().HasOne<User>(u => u.IntakeSuperVisionUser);
            modelBuilder.Entity<Vektis>().HasData(getVektisList());
        }

        protected List<Vektis> getVektisList()
        {
            List<Vektis> vektisList = new List<Vektis>();
            try
            {
                using (var reader = new StreamReader(@"C:\Users\onnov\Git\avans-2.1-c-stash-fysio-app\Data\VektisLijst.csv"))
                {
                    Boolean isFirstLine = true;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (isFirstLine)
                        {
                            isFirstLine = false;
                            continue;
                        }

                        var values = line.Split(',');

                        vektisList.Add(new Vektis()
                        {
                            Id = int.Parse(values[0]),
                            Position = values[1],
                            Text = values[2]
                        });
                    }
                }
            }catch (Exception e)
            {
                e.ToString();
            }
            return vektisList;
        }
    }
}
