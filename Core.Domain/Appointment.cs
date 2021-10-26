
using System;

namespace Core.Domain
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public DateTime Date { get; set; }

        private int AppointmentUserId { get; set; }
        public virtual User AppointmentUser { get; set; }

        private int AppointmentWithUserId { get; set; }
        public virtual User AppointmentWithUser { get; set; }

        private int AppointmentCreatedByUserId { get; set; }
        public virtual User AppointmentCreatedByUser { get; set; }
    }
}
