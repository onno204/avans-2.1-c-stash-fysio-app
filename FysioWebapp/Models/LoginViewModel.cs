using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FysioWebapp.Models
{
    public class LoginViewModel
    {

        private string _email;
        [Required]
        public virtual string Email
        {
            get => _email;
            set => _email = value.ToLower();
        }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
