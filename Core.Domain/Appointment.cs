
using System;

namespace Core.Domain
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public DateTime Date { get; set; }

        public User User { get; set; }

        public User WithUser { get; set; }

        public User CreatedByUser { get; set; }
    }
}
