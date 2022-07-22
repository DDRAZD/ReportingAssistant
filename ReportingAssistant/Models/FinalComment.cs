using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ReportingAssistant.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace ReportingAssistant.Models
{
    [Table("Final Comments", Schema = "nameofschema")]
    public class FinalComment
    {
        [Key]
        [Display(Name ="Final Comment ID")]
        public long FinalCommentID { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "no more than 50 charachters")]
        [MinLength(2, ErrorMessage = "no less than 2 characters")]
        public string Screen { get; set; }
        [Required]
        [MaxLength(10000, ErrorMessage = "no more than 10000 charachters")]
        [MinLength(2, ErrorMessage = "no less than 2 characters")]
        public string Description { get; set; }
       
        [ForeignKey("AdminUsers")]
        public string AdminUserId { get; set; }
        public virtual ApplicationUser AdminUsers { get; set; }
      
        [ForeignKey("Users")]
        public string UserID { get; set; }

        public virtual ApplicationUser Users{ get; set; }
        [Required]
        public DateTime DateOfFinalComment { get; set; }

        public string Attachment { get; set; }
        

        [Required]
        public long ProjectID { get; set; }
        public virtual Project Project { get; set; }
        


    }
}