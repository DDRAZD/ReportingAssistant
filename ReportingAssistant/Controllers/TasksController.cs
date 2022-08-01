using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportingAssistant.DomainModels;
using ReportingAssistant.ServiceContracts;
using ReportingAssistant.ServiceLayer;

namespace ReportingAssistant.Controllers
{
    public class TasksController : Controller
    {

        IServices services;
        // GET: Tasks

        public TasksController()
        {
            this.services = new Services();
        }

        public ActionResult Index(string SortColumn="TaskID", int PageNo=1, string IconClass= "fa-sort-asc")
        {
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            List<Task> tasks = services.GetTasks(HttpContext.User.Identity.Name);
           
            if (SortColumn == "TaskID")
            {
                if (IconClass == "fa-sort-asc")
                    tasks = tasks.OrderBy(y => y.TaskID).ToList();
                else
                    tasks = tasks.OrderByDescending(y => y.TaskID).ToList();
            }
            else if (SortColumn == "Screen")
            {
                if (IconClass == "fa-sort-asc")
                    tasks = tasks.OrderBy(y => y.Screen).ToList();
                else
                    tasks = tasks.OrderByDescending(y => y.Screen).ToList();

            }
            else if (SortColumn == "AdminID")
            {
                if (IconClass == "fa-sort-asc")
                    tasks = tasks.OrderBy(y => y.AdminUserId).ToList();
                else
                    tasks = tasks.OrderByDescending(y => y.AdminUserId).ToList();
            }
            else if (SortColumn == "ProjectID")
            {
                if (IconClass == "fa-sort-asc")
                    tasks = tasks.OrderBy(y => y.ProjectID).ToList();
                else
                    tasks = tasks.OrderByDescending(y => y.ProjectID).ToList();
            }
            else if (SortColumn == "DateOfTask")
            {
                if (IconClass == "fa-sort-asc")
                    tasks = tasks.OrderBy(y => y.DateOfTask).ToList();
                else
                    tasks = tasks.OrderByDescending(y => y.DateOfTask).ToList();

            }

            //paging - limiting the number of records per page displayed to the user
            int NoOfRecordsPerPage = 5;
            int NoOfPages =
                Convert.ToInt32(Math.Ceiling(Convert.ToDouble(tasks.Count) / Convert.ToDouble(NoOfRecordsPerPage))); //rounding up
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            tasks = tasks.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();



            return View(tasks);
            }

        public ActionResult ViewTask(long taskID)
        {
           Task task = services.GetTask(taskID);
            return View(task);
        }
        public ActionResult CompleteTask(long taskID)
        {
            Task task = services.GetTask(taskID);
            services.CompleteTask(task);
            return View();
        }

        
    }

    

        
    }
