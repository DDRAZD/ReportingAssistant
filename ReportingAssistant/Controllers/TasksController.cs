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

        public ActionResult Index()
        {
            return View();
        }
    }
}