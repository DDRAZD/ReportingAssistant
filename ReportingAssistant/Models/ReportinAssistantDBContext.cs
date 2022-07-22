using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ReportingAssistant.Models
{
    public class ReportinAssistantDBContext:IdentityDbContext<ApplicationUser>
    {

        //constructor for the DB

        public ReportinAssistantDBContext():base("MyConnectionString")
        {
            
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskDone> TasksDone { get; set; }
        public DbSet<FinalComment> FinalComments { get; set; }
    }
}