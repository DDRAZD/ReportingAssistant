using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using ReportingAssistant.DomainModels;
using ReportingAssistant.RepositoryContracts;
using ReportingAssistant.DataLayer;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ReportingAssistant.RepositoryLayer
{
    public class Repository : IRepository
    {
        ReportinAssistantDBContext dbContext;
        RoleManager<IdentityRole> roleManager;
        ApplicationUserStore appUserStore;
        ApplicationUserManager userManager;
        public Repository()
        {
           this.dbContext = new ReportinAssistantDBContext();

             roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext)); //this is for the table of role

             appUserStore = new ApplicationUserStore(dbContext);//this is for the table of users

            //creating an ability to manage roles and users:
             userManager = new ApplicationUserManager(appUserStore);


        }

        public void CreateProject(Project project )
        {
            dbContext.Projects.Add( project );
            dbContext.SaveChanges();
        }

        public void CreateTask(Task task)
        {
            Project project = dbContext.Projects.Find(task.ProjectID );
            task.Projects = project;
            dbContext.Tasks.Add(task);
            dbContext.SaveChanges();
        }

        public void CreateCategory(string categoryName)
        {
            Category category = new Category();
            category.CategoryName=categoryName;
            dbContext.Categories.Add(category);
            dbContext.SaveChanges ();
        }

        public List<Category> GetCategories()
        {
            return dbContext.Categories.ToList();
        }

       public  List<Project> GetProjects()
        {
            return dbContext.Projects.ToList();
        }

       public  List<ApplicationUser> GetUsers()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();
            foreach(var user in userManager.Users.ToList())
            {
                
               if( userManager.IsInRole<ApplicationUser,string>(user.Id, "User")==true)
                {
                    users.Add(user);
                }
            }
            return users;
        }

       public string GetUserID(string UserName)
        {
            ApplicationUser user = userManager.FindByName(UserName);
            if (user != null)
            {
                return user.Id;
            }
            else
            {
                return string.Empty;
            }
        }
        public void EditFinalComments(FinalComment finalComment)
        {
            throw new NotImplementedException();
        }

        public void EditTask(DomainModels.Task task)
        {
            throw new NotImplementedException();
        }

        public void EditTaskDone(TaskDone taskDone)
        {
            throw new NotImplementedException();
        }

        public List<FinalComment> GetFinalComments(string UserID)
        {
            throw new NotImplementedException();
        }

        public List<Task> GetTasks(string UserName)
        {
          string UserID=  GetUserID(UserName);
         return   dbContext.Tasks.Where(t => t.UserID == UserID).ToList();
        }

        public List<TaskDone> GetTasksDone(string UserID)
        {
            throw new NotImplementedException();
        }

        public void CompleteTask(Task task)
        {
            TaskDone taskDone = new TaskDone();
            taskDone.ProjectID = task.ProjectID;
            taskDone.DateOfTaskDone= DateTime.Now;
            taskDone.AdminUsers = task.AdminUsers;
            taskDone.Attachment=task.Attachment;
            taskDone.Description=task.Description;
            taskDone.Screen=task.Screen;   
            taskDone.Users=task.Users;
            dbContext.TasksDone.Add(taskDone);
            dbContext.Tasks.Remove(task);
            dbContext.SaveChanges();
        }

      public  Task GetTask(long TaskID)
        {
           return dbContext.Tasks.FirstOrDefault(y=>y.TaskID == TaskID);
        }
    }
}
