using Core.Domain;
using System;

namespace FysioWebapp.Models
{
    public class AvailabilityModel
    {
        public AvailabilityDay AvailabilityDay { get; set; }
        public float StartTime { get; set; }
        public float EndTime { get; set; }
    }
}
