using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using ReportingAssistant.DomainModels;


namespace ReportingAssistant.ServiceContracts
{
    public interface IServices
    {
        List<Task> GetTasks(string UserName);
        List<Category> GetCategories();
        List<TaskDone> GetTasksDone(string UserName);
        List<FinalComment> GetFinalComments(string UserID);

        List<Project> GetProjects();

        List<ApplicationUser> GetUsers();
        string GetUserID(string UserName);

        void CreateTask(Task task);

        void EditTask(Task task);
        void CompleteTask(Task task);

        Task GetTask(long TaskID);

        TaskDone GetTaskDone(long TaskID);
        void EditTaskDone(TaskDone taskDone);

        void EditFinalComments(FinalComment finalComment);

        void CreateProject(Project project);

        void CreateCategory(string categoryName);

        ApplicationUser FindUser(string Username, string Password);
        ApplicationUser FindUserByID(string UserID);

        bool IsAdmin(ApplicationUser User);

        System.Security.Claims.ClaimsIdentity CreateIdentity(ApplicationUser user);

        void ChangePassword(string newPassword, string userID);

        string CreateNewUser(string Email, string UserName, string PasswordHash, string City, string Country, string Address, string PhoneNumber);






    }
}
