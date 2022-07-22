using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportingAssistant.Models;
using ReportingAssistant.Filters;

namespace ReportingAssistant.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        // GET: Admin/Users
        [MyAuthenticationFilter]
        [AdminAuthroization]
        public ActionResult Index()
        {
            ReportinAssistantDBContext db = new ReportinAssistantDBContext();
            List<ApplicationUser> existingUsers = db.Users.ToList();//pulling all user information from DB
            return View(existingUsers);
        }
    }
}