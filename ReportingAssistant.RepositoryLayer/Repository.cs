using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void CreateProject()
        {
            throw new NotImplementedException();
        }

        public void CreateTask(string UserID, Project project)
        {
            throw new NotImplementedException();
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
