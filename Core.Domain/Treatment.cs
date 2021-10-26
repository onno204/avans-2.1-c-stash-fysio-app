﻿
using System;

namespace Core.Domain
{
    public class Treatment
    {
        public int TreatmentId { get; set; }

        public int VektisId { get; set; }

        public string VektisExplanation { get; set; }

        public string Description { get; set; }

        public TreatmentRoom Room { get; set; }

        public DateTime Date { get; set; }

        public int TreatmentUserId { get; set; }
        public virtual User TreatmentUser { get; set; }

        public int CarriedOutByUserId { get; set; }
        public virtual User CarriedOutByUser { get; set; }
    }
}
