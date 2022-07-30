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
        List<Task> GetTasks(string UserID);
        List<Category> GetCategories();
        List<TaskDone> GetTasksDone(string UserID);
        List<FinalComment> GetFinalComments(string UserID);

        List<Project> GetProjects();

        List<ApplicationUser> GetUsers();
        string GetUserID(string UserName);

        void CreateTask(Task task);

        void EditTask(Task task);

        void EditTaskDone(TaskDone taskDone);

        void EditFinalComments(FinalComment finalComment);

        void CreateProject(Project project);

        void CreateCategory(string categoryName);   


        

        
    }
}
