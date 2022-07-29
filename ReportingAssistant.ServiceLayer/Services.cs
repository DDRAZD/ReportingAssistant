using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using ReportingAssistant.ServiceContracts;
using ReportingAssistant.DomainModels;
using ReportingAssistant.RepositoryLayer;
using ReportingAssistant.RepositoryContracts;


namespace ReportingAssistant.ServiceLayer
{
    public class Services : IServices
    {
        IRepository repository;

        public Services()
        {
            repository = new Repository();
        }
        
        public List<Category> GetCategories()
        {
          return  repository.GetCategories();
        }


       public  List<Project> GetProjects()
        {
            return repository.GetProjects();
        }

        public List<ApplicationUser> GetUsers()
        {
            return repository.GetUsers();
        }
        public void CreateCategory(string categoryName)
        {
            repository.CreateCategory(categoryName);
        }

        public void CreateProject(Project project)
        {
            this.repository.CreateProject(project);
        }

        public void CreateTask(Task task)
        {
            repository.CreateTask(task);
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
