using System;
using Core.Domain;

namespace FysioWebapp.Models
{
    public class UsersViewModel
    {
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

    }
}
