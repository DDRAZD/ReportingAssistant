using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportingAssistant.DomainModels;
//using ReportingAssistant.DataLayer;
using Microsoft.AspNet.Identity;
using ReportingAssistant.Filters;
using ReportingAssistant.ServiceContracts;
using ReportingAssistant.ServiceLayer;

namespace ReportingAssistant.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        IServices services;


        public HomeController()
        {
            this.services = new Services();
        }
        // GET: Admin/Home
        [MyAuthenticationFilter]
        [AdminAuthroization]
        public ActionResult Index()
        {
            /* var appDbContext = new ReportinAssistantDBContext();
             var userStore = new ApplicationUserStore(appDbContext);
             var userManager = new ApplicationUserManager(userStore);*/

            //ApplicationUser appUser = userManager.FindById(User.Identity.GetUserId());
            ApplicationUser appUser = services.FindUserByID(User.Identity.GetUserId());
            return View(appUser);
        }
    }
}