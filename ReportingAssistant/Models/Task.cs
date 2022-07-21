using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ReportingAssistant.Models
{
    public class Task
    {
        [Key]
        [Display(Name ="Task ID")]
        public long TaskID { get; set; }

        [Required(ErrorMessage ="Screem cannot be blank")]
        [MaxLength(50, ErrorMessage ="no more than 50 charachters")]
        [MinLength(2, ErrorMessage ="no less than 2 characters")]

        public string Screen { get; set; }
        [Required(ErrorMessage = "Description cannot be blank")]
        [MaxLength(10000, ErrorMessage = "no more than 50 charachters")]
        [MinLength(2, ErrorMessage = "no less than 2 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage ="you must specify an admin")]
        public long AdminUserID { get; set; }

        [Required(ErrorMessage = "you must specify a user")]
        public long UserID { get; set; }

        [Required(ErrorMessage ="must specfic task date")]
        public DateTime DateOfTask { get; set; }

        public string Attachment { get; set; }

        [Required(ErrorMessage ="Task's project ID cannot be null")]
        public long ProjectID { get; set; }
    }
}