using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportingAssistant.DomainModels;
using ReportingAssistant.ServiceContracts;
using ReportingAssistant.ServiceLayer;


namespace ReportingAssistant.Areas.Admin.Controllers
{
    public class ProjectsController : Controller
    {

        IServices services;


        public ProjectsController()
        {
            this.services = new Services();
        }
        // GET: Admin/Projects
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            services.CreateCategory(category.CategoryName);
            return RedirectToAction("Index","Projects");
        }


        public ActionResult CreateProject()
        {
            ViewData["Categories"] = services.GetCategories();
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(Project project)
        {

            services.CreateProject(project);
            return RedirectToAction("Index", "Projects");
        }
    }
}