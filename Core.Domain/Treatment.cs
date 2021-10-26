
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class Treatment
    {
        public int Id { get; set; }

        public int VektisId { get; set; }

        public string VektisExplanation { get; set; }

        public string Description { get; set; }

        public TreatmentRoom Room { get; set; }

        public DateTime Date { get; set; }

        private int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        private int? CarriedOutByUserId { get; set; }
        [ForeignKey("CarriedOutByUserId")]
        public virtual User CarriedOutByUser { get; set; }
    }
}
