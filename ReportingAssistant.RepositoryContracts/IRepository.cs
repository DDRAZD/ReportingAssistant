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

        void CreateTask(string UserID, Project project);

        void EditTask(Task task);

        void EditTaskDone(TaskDone taskDone);

        void EditFinalComments(FinalComment finalComment);

        void CreateProject();

    }
}
