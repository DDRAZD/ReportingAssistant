using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//allows to create rules around the paramaters

namespace ReportingAssistant.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="user name cannot be empty")]
        public string Username { get; set; }
        [Required(ErrorMessage = "password cannot be empty")]
        public string Password { get; set; }
    }
}