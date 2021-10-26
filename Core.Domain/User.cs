using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class User
    {
        public int UserId { get; set; }

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

        public User? IntakeUser { get; set; }

        public User? IntakeSuperVisionUser { get; set; }

        public User? MainTherapist { get; set; }

#nullable disable
        [InverseProperty("User")]
        public ICollection<Comment> Comments { get; set; }

        [InverseProperty("User")]
        public ICollection<Treatment> TreatmentHistory { get; set; }

        [InverseProperty("User")]
        public ICollection<Appointment> Appointments { get; set; }

        public int DcsphCode { get; set; }

        public string DcsphDescription { get; set; }

        public string GlobalDescriptionComplaints { get; set; }

        public string TreatmentPlan { get; set; }


    }
}
