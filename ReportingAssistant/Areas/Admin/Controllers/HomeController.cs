using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportingAssistant.Identity;
using Microsoft.AspNet.Identity;

namespace ReportingAssistant.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            ApplicationUser appUser = userManager.FindById(User.Identity.GetUserId());
            return View(appUser);
        }
    }
}