using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ReportingAssistant.Models
{
    public class ReportinAssistantDBContext:DbContext
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