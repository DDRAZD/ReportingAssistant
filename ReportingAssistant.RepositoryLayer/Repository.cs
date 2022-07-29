using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using ReportingAssistant.DomainModels;
using ReportingAssistant.RepositoryContracts;
using ReportingAssistant.DataLayer;

namespace ReportingAssistant.RepositoryLayer
{
    public class Repository : IRepository
    {
        ReportinAssistantDBContext dbContext;

        public Repository()
        {
           this.dbContext = new ReportinAssistantDBContext();   
        }

        public void CreateProject(Project project )
        {
            dbContext.Projects.Add( project );
            dbContext.SaveChanges();
        }

        public void CreateTask(Task task)
        {
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
            return dbContext.Users.ToList();
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

        public List<DomainModels.Task> GetTasks(string UserID)
        {
            throw new NotImplementedException();
        }

        public List<TaskDone> GetTasksDone(string UserID)
        {
            throw new NotImplementedException();
        }
    }
}
