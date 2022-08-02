using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using ReportingAssistant.DomainModels;
using Microsoft.AspNet.Identity;


namespace ReportingAssistant.RepositoryContracts
{
    public interface IRepository
    {
        List<Task> GetTasks(string UserName);
        List<TaskDone> GetTasksDone(string UserName);
        List<FinalComment> GetFinalComments(string UserID);
        List<Category> GetCategories();

        List<Project> GetProjects();

        List<ApplicationUser> GetUsers();

        string GetUserID(string UserName);

        void CreateTask(Task task);

        void CreateCategory(string categoryName);

        void CompleteTask(Task task);

        Task GetTask(long TaskID);

        TaskDone GetTaskDone(long TaskID);
        void EditTask(Task task);

        void EditTaskDone(TaskDone taskDone);

        void EditFinalComments(FinalComment finalComment);

        void CreateProject(Project project);

        ApplicationUser FindUser(string Username, string Password);
        ApplicationUser FindUserByID(string UserID);

        bool IsAdmin(ApplicationUser User);

        System.Security.Claims.ClaimsIdentity CreateIdentity(ApplicationUser user);

        void ChangePassword(string newPassword, string userID);

        string CreateUser(ApplicationUser user);

    }
}
