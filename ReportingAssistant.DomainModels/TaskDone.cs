﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingAssistant.DomainModels
{
    [Table("TasksDone", Schema = "nameofschema")]
    public class TaskDone
    {
        [Key]
        [Display(Name = "Task Done ID")]
        public long TaskDoneID { get; set; }

        [Required(ErrorMessage = "Screem cannot be blank")]
        [MaxLength(50, ErrorMessage = "no more than 50 charachters")]
        [MinLength(2, ErrorMessage = "no less than 2 characters")]

        public string Screen { get; set; }
        [Required(ErrorMessage = "Description cannot be blank")]
        [MaxLength(10000, ErrorMessage = "no more than 50 charachters")]
        [MinLength(2, ErrorMessage = "no less than 2 characters")]
        public string Description { get; set; }

        
        [ForeignKey("AdminUsers")]
        public string AdminUserId { get; set; }
        public virtual ApplicationUser AdminUsers { get; set; }
       
        [ForeignKey("Users")]
        public string UserID { get; set; }

        public virtual ApplicationUser Users { get; set; }

        [Required(ErrorMessage = "must specfic task done date")]
        public DateTime DateOfTaskDone { get; set; }

        public string Attachment { get; set; }

        [Required(ErrorMessage = "Task's project ID cannot be null")]
        [ForeignKey("Projects")]
        public long ProjectID { get; set; }
        public virtual Project Projects { get; set; }
    }
}