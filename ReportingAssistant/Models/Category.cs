using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ReportingAssistant.Models
{
    public class Category
    {
        [Key]
        [Display(Name ="Category ID")]
        public long CategoryID { get; set; }
        [Required(ErrorMessage ="Category name cannot be empty")]
        [RegularExpression(@"^[A-Za-z0-9 ]*$",ErrorMessage ="Only letters, space and digits in Category Name")]
        public string CategoryName { get; set; }
    }
}