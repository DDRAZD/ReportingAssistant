using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using ReportingAssistant.ServiceContracts;
using ReportingAssistant.DomainModels;
using ReportingAssistant.RepositoryLayer;
using ReportingAssistant.RepositoryContracts;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;



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
       public string GetUserID(string UserName)
        {
            return repository.GetUserID(UserName);
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

        public List<DomainModels.Task> GetTasks(string UserName)
        {
            return repository.GetTasks(UserName);
        }

        public List<TaskDone> GetTasksDone(string UserID)
        {
            throw new NotImplementedException();
        }
        public void CompleteTask(Task task)
        {
            repository.CompleteTask(task);
        }

       public  Task GetTask(long TaskID)
        {
           return repository.GetTask(TaskID);
        }

       public  ApplicationUser FindUser(string Username, string Password)
        {
          return repository.FindUser(Username, Password);
        }

        public ApplicationUser FindUserByID(string UserID)
        {
            return repository.FindUserByID(UserID);
        }

        public bool IsAdmin(ApplicationUser User)
        {
            return repository.IsAdmin(User);
        }

        public System.Security.Claims.ClaimsIdentity CreateIdentity( ApplicationUser user)
        {
            
            return repository.CreateIdentity(user);
            
        }

        public void ChangePassword(string newPassword, string userID)
        {
            repository.ChangePassword(newPassword, userID);
        }

       public string CreateNewUser(string Email, string UserName, string PasswordHash, string City, string Country, string Address, string PhoneNumber)
        {
            var user = new ApplicationUser() { Email = Email, UserName = UserName, PasswordHash = PasswordHash, City = City, Country = Country, Address = Address, PhoneNumber = PhoneNumber };

            string result = repository.CreateUser(user);
           
            return result;
        }
    }
}
