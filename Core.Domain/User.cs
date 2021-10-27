using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        private string _email;

        public virtual string Email
        {
            get => _email;
            set => _email = value.ToLower();
        }

        private DateTime _birthDate;

        public virtual DateTime BirthDate
        {
            get => _birthDate;

            set
            {
                var age = new DateTime((DateTime.Now - value).Ticks).Year;

                if (age > 16)
                {
                    _birthDate = value;
                }
                else
                {
                    throw new InvalidOperationException("Birthdate must be more than 16 years ago");
                }
            }
        }

        public UserType UserType { get; set; }

        public int AdditionalIdentifier { get; set; }


        public Gender Gender { get; set; }

        public DateTime EndDateTreatment { get; set; }

        public DateTime SignUpDate { get; set; }

#nullable enable
        public string? Picture { get; set; }

        public string? Password { get; set; }

#nullable disable
        private int? IntakeUserId { get; set; }
        [ForeignKey("IntakeUserId")] public virtual User IntakeUser { get; set; }

        private int? IntakeSuperVisionUserId { get; set; }

        [ForeignKey("IntakeSuperVisionUserId")]
        public virtual User IntakeSuperVisionUser { get; set; }

        private int? MainTherapistId { get; set; }
        [ForeignKey("MainTherapistId")] public virtual User MainTherapist { get; set; }

        [InverseProperty("User")] 
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        [InverseProperty("User")]
        public virtual ICollection<Treatment> TreatmentHistory { get; set; } = new List<Treatment>();

        [InverseProperty("User")]
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public int DcsphCode { get; set; }

        public string DcsphDescription { get; set; }

        public string GlobalDescriptionComplaints { get; set; }

        public string TreatmentPlan { get; set; }


    }
}
