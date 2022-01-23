

using System;
using System.ComponentModel.DataAnnotations;

namespace FysioWebapp.Models
{
    public class AddAppointmentViewModel
    {
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}