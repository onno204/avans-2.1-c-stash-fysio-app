using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FysioWebapp.Models
{
    public class LoginViewModel
    {

        private string _employeeEmail;
        public virtual string EmployeeEmail
        {
            get => _employeeEmail;
            set => _employeeEmail = value.ToLower();
        }

        private string _patientEmail;
        public virtual string PatientEmail
        {
            get => _patientEmail;
            set => _patientEmail = value.ToLower();
        }

        [Required]
        public string TargetSubmitButton { get; set; }

        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
