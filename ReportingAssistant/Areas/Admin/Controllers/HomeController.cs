using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportingAssistant.Models;
using Microsoft.AspNet.Identity;
using ReportingAssistant.Filters;

namespace ReportingAssistant.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        [MyAuthenticationFilter]
        [AdminAuthroization]
        public ActionResult Index()
        {
            var appDbContext = new ReportinAssistantDBContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            ApplicationUser appUser = userManager.FindById(User.Identity.GetUserId());
            return View(appUser);
        }
    }
}