
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        private int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        private int? AppointmentWithUserId { get; set; }
        [ForeignKey("AppointmentWithUserId")]
        public virtual User AppointmentWithUser { get; set; }

        private int? AppointmentCreatedByUserId { get; set; }
        [ForeignKey("AppointmentCreatedByUserId")]
        public virtual User AppointmentCreatedByUser { get; set; }
    }
}
