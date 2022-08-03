using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ReportingAssistant.Filters;
using ReportingAssistant.DomainModels;
using ReportingAssistant.ServiceContracts;
//using ReportingAssistant.ServiceLayer;

namespace ReportingAssistant.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {

        IServices services;

        public UsersController(IServices servicesInjected)
        {
           // this.services=new Services();
           this.services = servicesInjected;
        }
        // GET: Admin/Users
        [MyAuthenticationFilter]
        [AdminAuthroization]
        public ActionResult Index()
        {
           
                      
            
            List<ApplicationUser> existingUsers = services.GetUsers();
            return View(existingUsers);
        }
    }
}