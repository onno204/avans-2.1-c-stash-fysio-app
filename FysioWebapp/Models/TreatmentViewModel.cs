using System;
using Core.Domain;

namespace FysioWebapp.Models
{
    public class TreatmentViewModel
    {
        public int Id { get; set; }

        public int VektisId { get; set; }

        public string VektisExplanation { get; set; }

        public string Description { get; set; }

        public TreatmentRoom Room { get; set; }

        public DateTime Date { get; set; }

        public UserViewModel CarriedOutByUser { get; set; }

    }
}
