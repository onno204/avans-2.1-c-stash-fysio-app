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
                SessionDuration = user.SessionDuration,
                SessionsPerWeek = user.SessionsPerWeek,
                EndDateTreatment = user.EndDateTreatment,
                UserType = user.UserType,
                AdditionalIdentifier = user.AdditionalIdentifier,
                SignUpDate = user.SignUpDate,
                IntakeSuperVisionUserId = user.IntakeSuperVisionUser?.Id,
                IntakeUserId = user.IntakeUser?.Id,
                MainTherapistId = user.MainTherapist?.Id,
                Availability = user.UserAvailability.ToList().ToViewModel(),
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
            return new CommentViewModel
            {
                Id = comment.Id,
                CommentMadeBy = comment.CommentMadeBy.ToViewModel(),
                CommentText = comment.CommentText,
                Date = comment.Date,
                PubliclyVisible = comment.PubliclyVisible
            };
        }

        public static TreatmentViewModel ToViewModel(this Treatment treatment)
        {
            return new TreatmentViewModel()
            {
                Id = treatment.Id,
                CarriedOutByUser = treatment.User.ToViewModel(),
                Date = treatment.Date,
                Description = treatment.Description,
                Room = treatment.Room,
                VektisExplanation = treatment.VektisExplanation,
                VektisId = treatment.VektisId
            };
        }

        public static AppointmentViewModel ToViewModel(this Appointment appointment)
        {
            return new AppointmentViewModel()
            {
                Id = appointment.Id,
                StartDate = appointment.StartDate,
                EndDate = appointment.EndDate,
                AppointmentCreatedByUser = appointment.AppointmentCreatedByUser.ToViewModel(),
                AppointmentWithUser = appointment.AppointmentWithUser.ToViewModel()
            };
        }
        public static List<AvailabilityModel> ToViewModel(this List<Availability> availabilities)
        {
            List<AvailabilityModel> availabilityList = new List<AvailabilityModel>();
            availabilities.ForEach(model =>
            {
                availabilityList.Add(new AvailabilityModel()
                {
                    AvailabilityDay = model.AvailabilityDay,
                    EndTime = model.EndTime,
                    StartTime = model.StartTime
                });
            });
            return availabilityList;
        }

        public static List<Availability> ToModel(this List<AvailabilityModel> availabilities)
        {
            List<Availability> availabilityList = new List<Availability>();
            availabilities.ForEach(model =>
            {
                availabilityList.Add(new Availability()
                {
                    AvailabilityDay = model.AvailabilityDay,
                    EndTime = model.EndTime,
                    StartTime = model.StartTime
                });
            });
            return availabilityList;
        }
    }
}
