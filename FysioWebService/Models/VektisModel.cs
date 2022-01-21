using System;
using Core.Domain;

namespace FysioWebapp.Models
{
    public class VektisModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public UserViewModel AppointmentWithUser { get; set; }

        public UserViewModel AppointmentCreatedByUser { get; set; }
    }
}

