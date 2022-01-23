using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Availability
    {
        public int Id { get; set; }
        private int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public AvailabilityDay AvailabilityDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
