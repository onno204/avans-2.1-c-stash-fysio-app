using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;

namespace FysioWebapp.Models
{
    public static class ViewModelHelper
    {
        public static List<UserViewModel> ToViewModel(this IEnumerable<User> users)
        {
            var result = new List<UserViewModel>();

            foreach (var user in users)
            {
                result.Add(user.ToViewModel());
            }

            return result;
        }

        public static UserViewModel ToViewModel(this User user)
        {
            if (user == null)
            {
                return null;
            }
            var result = new UserViewModel
            {
                Id = user.Id,
                BirthDate = user.BirthDate,
                Email = user.Email,
                FullName = user.FullName,
                DcsphDescription = user.DcsphDescription,
                GlobalDescriptionComplaints = user.GlobalDescriptionComplaints,
                DcsphCode = user.DcsphCode,
                EndDateTreatment = user.EndDateTreatment,
                UserType = user.UserType,
                AdditionalIdentifier = user.AdditionalIdentifier,
                SignUpDate = user.SignUpDate,
                IntakeSuperVisionUserId = user.IntakeSuperVisionUser?.Id,
                IntakeUserId = user.IntakeUser?.Id,
                MainTherapistId = user.MainTherapist?.Id,
                Comments = new List<CommentViewModel>(),
                Appointments = new List<AppointmentViewModel>(),
                TreatmentHistory = new List<TreatmentViewModel>()
            };
            foreach (Comment comment in user.Comments)
            {
                result.Comments.Add(comment.ToViewModel());
            }
            foreach (Appointment appointment in user.Appointments)
            {
                result.Appointments.Add(appointment.ToViewModel());
            }
            foreach (Treatment treatment in user.TreatmentHistory)
            {
                result.TreatmentHistory.Add(treatment.ToViewModel());
            }
            return result;
        }

        public static CommentViewModel ToViewModel(this Comment comment)
        {
            var result = new CommentViewModel
            {
                Id = comment.Id,
                CommentMadeBy = comment.CommentMadeBy.ToViewModel(),
                CommentText = comment.CommentText,
                Date = comment.Date,
                PubliclyVisible = comment.PubliclyVisible
            };

            return result;
        }

        public static TreatmentViewModel ToViewModel(this Treatment treatment)
        {
            var result = new TreatmentViewModel()
            {
                Id = treatment.Id,
                CarriedOutByUser = treatment.User.ToViewModel(),
                Date = treatment.Date,
                Description = treatment.Description,
                Room = treatment.Room,
                VektisExplanation = treatment.VektisExplanation,
                VektisId = treatment.VektisId
            };

            return result;
        }

        public static AppointmentViewModel ToViewModel(this Appointment appointment)
        {
            var result = new AppointmentViewModel()
            {
                Id = appointment.Id,
                Date = appointment.Date,
                AppointmentCreatedByUser = appointment.AppointmentCreatedByUser.ToViewModel(),
                AppointmentWithUser = appointment.AppointmentWithUser.ToViewModel()
            };

            return result;
        }
    }
}
