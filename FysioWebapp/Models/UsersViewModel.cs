using System;
using Core.Domain;

namespace FysioWebapp.Models
{
    public class UsersViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public UserType UserType { get; set; }

        public int AdditionalIdentifier { get; set; }

        public string GlobalDescriptionComplaints { get; set; }

        public int DcsphCode { get; set; }

        public string DcsphDescription { get; set; }

        public DateTime EndDateTreatment { get; set; }

        public int IntakeUserId { get; set; }

        public int? IntakeSuperVisionUserId { get; set; }

        public int MainTherapistId { get; set; }

        public DateTime SignUpDate { get; set; }

    }
}
