using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportingAssistant.DomainModels;
using ReportingAssistant.ServiceContracts;
using ReportingAssistant.ServiceLayer;
using ReportingAssistant.Filters;


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
        [MyAuthenticationFilter]
        [AdminAuthroization]
        public ActionResult Index()
        {
            return View();
        }
        [MyAuthenticationFilter]
        [AdminAuthroization]
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

        [MyAuthenticationFilter]
        [AdminAuthroization]
        public ActionResult CreateProject()
        {
            ViewData["Categories"] = services.GetCategories();
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            //Request.Files is an array that catches all the files submitted to the browser (built in)


            if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0]; //assuming only one file was submitted; this also requires the encrypt type to be set in the view
                var imgBytes = new Byte[file.ContentLength]; //creating a byte array to store the file (better as more encrypted)
                file.InputStream.Read(imgBytes, 0, file.ContentLength); // writing all the bytes from the file into imgBytes
                var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);//convert the bytes to string before storing in DB
                project.Photo = base64String;
            }
           

            services.CreateProject(project);
            return RedirectToAction("Index", "Projects");
        }
        [MyAuthenticationFilter]
        [AdminAuthroization]
        public ActionResult SeeProjects()
        {
            List<Project> projects = services.GetProjects();
            return View(projects);
        }
        [MyAuthenticationFilter]
        [AdminAuthroization]
        public ActionResult SeeCategories()
        {
            List<Category> categories = services.GetCategories();
            return View(categories);
           
        }
    }
}