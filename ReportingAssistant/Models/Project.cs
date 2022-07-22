using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ReportingAssistant.Models
{
    [Table("Projects", Schema="nameofschema")]
    public class Project
    {
        [Key]
        [Display(Name ="Project ID")]
        public long ProjectID { get; set; }


        [Required(ErrorMessage ="Projet name cannot be empty")]
        [Display(Name ="Project Name")]
        public string ProjectName { get; set; }
        
        public Nullable<DateTime> DateOfStart { get; set; }
        [Display(Name ="Avialablity Status")]
        [Required]
        public string AvailablityStatus { get; set; }

        [Display(Name ="Category ID")]
        [Required(ErrorMessage ="You must choose a category")]
        [ForeignKey("Categories")]
        public long CategoryID { get; set; }
        public virtual Category Categories { get; set; }

        public string Photo { get; set; }
    }
}