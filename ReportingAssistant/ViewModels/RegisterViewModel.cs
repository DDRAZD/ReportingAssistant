using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//allows to create rules around the paramaters

namespace ReportingAssistant.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="must have a user name")]
        public string Username { get; set; }
        [Required(ErrorMessage = "must have a password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "must confirm password")]
        [Compare("Password", ErrorMessage ="password dont match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "must have a email")]
        [EmailAddress(ErrorMessage="please enter correct email format")]
        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}