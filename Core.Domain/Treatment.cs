
using System;

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

        public User CarriedOutByUser { get; set; }
    }
}
