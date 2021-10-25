
using System;

namespace Core.Domain
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public User WithUser { get; set; }

        public User CreatedByUser { get; set; }
    }
}
