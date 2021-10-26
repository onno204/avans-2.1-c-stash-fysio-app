
using System;

namespace Core.Domain
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public DateTime Date { get; set; }

        public int AppointmentUserId { get; set; }
        public virtual User AppointmentUser { get; set; }

        public int AppointmentWithUserId { get; set; }
        public virtual User AppointmentWithUser { get; set; }

        public int AppointmentCreatedByUserId { get; set; }
        public virtual User AppointmentCreatedByUser { get; set; }
    }
}
