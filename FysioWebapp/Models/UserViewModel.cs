﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Domain;

namespace FysioWebapp.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }
        public int SessionsPerWeek { get; set; }
        public float SessionDuration { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public UserType UserType { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public int AdditionalIdentifier { get; set; }
        
        [Required]
        public string GlobalDescriptionComplaints { get; set; }

        [Required]
        public int DcsphCode { get; set; }

        public string DcsphDescription { get; set; }

        [Required]
        public DateTime EndDateTreatment { get; set; }

        public int? IntakeUserId { get; set; }

        public int? IntakeSuperVisionUserId { get; set; }

        public int? MainTherapistId { get; set; }

        [Required]
        public DateTime SignUpDate { get; set; }
        public List<AvailabilityModel> Availability { get; set; } = new List<AvailabilityModel>();

        public List<CommentViewModel> Comments { get; set; } = new List<CommentViewModel>();
#nullable enable
        public string? CommentsInput { get; set; }
#nullable disable
        public bool CommentsPublic { get; set; }

        public List<AppointmentViewModel> Appointments { get; set; } = new List<AppointmentViewModel>();

        public List<TreatmentViewModel> TreatmentHistory { get; set; } = new List<TreatmentViewModel>();

    }
}
