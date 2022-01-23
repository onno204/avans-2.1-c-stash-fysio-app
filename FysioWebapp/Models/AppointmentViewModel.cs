using System;
using Core.Domain;

namespace FysioWebapp.Models
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public UserViewModel AppointmentWithUser { get; set; }

        public UserViewModel AppointmentCreatedByUser { get; set; }
    }
}