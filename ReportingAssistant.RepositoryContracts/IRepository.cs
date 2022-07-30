using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using ReportingAssistant.DomainModels;

namespace ReportingAssistant.RepositoryContracts
{
    public interface IRepository
    {
        List<Task> GetTasks(string UserID);
        List<TaskDone> GetTasksDone(string UserID);
        List<FinalComment> GetFinalComments(string UserID);
        List<Category> GetCategories();

        List<Project> GetProjects();

        List<ApplicationUser> GetUsers();

        string GetUserID(string UserName);

        void CreateTask(Task task);

        void CreateCategory(string categoryName);

        void EditTask(Task task);

        void EditTaskDone(TaskDone taskDone);

        void EditFinalComments(FinalComment finalComment);

        void CreateProject(Project project);

    }
}
