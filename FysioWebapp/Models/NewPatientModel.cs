using System;
using System.Collections.Generic;
using Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace FysioWebapp.Models
{
    public class NewPatientModel
    {
        [Required]
        public string FullName { get; set; }

        private string _email;
        [Required]
        public virtual string Email
        {
            get => _email;
            set => _email = value.ToLower();
        }

        private DateTime _birthDate;
        [Required]
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

        [Required]
        public UserType UserType { get; set; }

        [Required]
        public int AdditionalIdentifier { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateTime EndDateTreatment { get; set; }

        [Required]
        public DateTime SignUpDate { get; set; }

        [Required]
        public int IntakeUserId { get; set; }

#nullable enable
        public string? Picture { get; set; }

        public int? IntakeSuperVisionUserId { get; set; }
#nullable disable

        [Required]
        public int MainTherapistId { get; set; }

        [Required]
        public string CommentsInput { get; set; }

        [Required]
        public int DcsphCode { get; set; }

        [Required]
        public string DcsphDescription { get; set; }

        [Required]
        public string GlobalDescriptionComplaints { get; set; }

        public string TreatmentPlan { get; set; }
    }
}