using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class Availability
    {
        public int Id { get; set; }
        private int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public AvailabilityDay AvailabilityDay { get; set; }
        public float StartTime { get; set; }
        public float EndTime { get; set; }
    }
}
