using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get => _birthDate;

            set
            {
                int Age = new DateTime((DateTime.Now - value).Ticks).Year;

                if (Age > 16)
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

        public string Picture { get; set; }

        public Gender Gender { get; set; }

        public DateTime EndDateTreatment { get; set; }

        public DateTime SignUpDate { get; set; }

#nullable enable
        public User? IntakeUser { get; set; }

        public User? SuperVisionUser { get; set; }

        public User? MainTherapist { get; set; }

#nullable disable
        public ICollection<Comment> Comments { get; set; }

        public ICollection<Treatment> TreatmentHistory { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public int DcsphCode { get; set; }

        public string DcsphDescription { get; set; }

        public string GlobalDescriptionComplaints { get; set; }

        public string TreatmentPlan { get; set; }


    }
}
