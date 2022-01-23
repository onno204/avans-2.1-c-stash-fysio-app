using Core.Domain;
using System;

namespace FysioWebapp.Models
{
    public class AvailabilityModel
    {
        public AvailabilityDay AvailabilityDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
