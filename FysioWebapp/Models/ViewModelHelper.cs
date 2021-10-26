using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;

namespace FysioWebapp.Models
{
    public static class ViewModelHelper
    {
        public static List<UsersViewModel> ToViewModel(this IEnumerable<User> users)
        {
            var result = new List<UsersViewModel>();

            foreach (var user in users)
            {
                result.Add(user.ToViewModel());
            }

            return result;
        }

        public static UsersViewModel ToViewModel(this User user)
        {
            var result = new UsersViewModel
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
                IntakeSuperVisionUserId = user.IntakeSuperVisionUser.Id,
                IntakeUserId = user.IntakeUser.Id,
                MainTherapistId = user.MainTherapist.Id
            };

            return result;
        }
    }
}
