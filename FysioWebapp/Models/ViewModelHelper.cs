using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;

namespace FysioWebapp.Models
{
    public static class ViewModelHelper
    {
        public static List<UsersViewModel> ToViewModel(this IEnumerable<User> games)
        {
            var result = new List<UsersViewModel>();

            foreach (var user in games)
            {
                result.Add(user.ToViewModel());
            }

            return result;
        }

        public static UsersViewModel ToViewModel(this User user)
        {
            var result = new UsersViewModel
            {
                UserId = user.UserId,
                BirthDate = user.BirthDate,
                Email = user.Email,
                FullName = user.FullName
            };

            return result;
        }
    }
}
