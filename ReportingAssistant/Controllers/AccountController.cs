using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportingAssistant.ViewModels;
using ReportingAssistant.Identity;
using Microsoft.AspNet.Identity;
using System.Web.Helpers;
using ReportingAssistant.Filters;

namespace ReportingAssistant.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
       

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(RegisterViewModel lvm)
        {
            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            var user = userManager.Find(lvm.Username, lvm.Password);
            if (user != null)
            {
                this.LoginUser(userManager, user);
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                return RedirectToAction("UserHome", "Account");
            }
            else
            {
                ModelState.AddModelError("myerror", "Invalid username or password");
                return View();

            }
           
        }

        [MyAuthenticationFilter]
        public ActionResult UserHome()
        {
            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            ApplicationUser appUser = userManager.FindById(User.Identity.GetUserId());
            return View(appUser);
        }


        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)//validation is valid of all the formats and required fields
            {
                //register
                var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);
                var passwordHash = Crypto.HashPassword(rvm.Password);
                var user = new ApplicationUser() { Email = rvm.Email, UserName = rvm.Username, PasswordHash = passwordHash, City = rvm.City, Country = rvm.Country, Address = rvm.Address, PhoneNumber = rvm.Mobile };

                IdentityResult result = userManager.Create(user);

                if (result.Succeeded)
                {
                    //role
                    userManager.AddToRole(user.Id, "User");

                    //  LoginUser(userManager, user);
                    this.LoginUser(userManager, user);
                    return RedirectToAction("UserHome", "Account");

                }

                return RedirectToAction("Register", "Account");
            }
            else
            {
                ModelState.AddModelError("My Error", "THe registration was not valid");
                return View();//redirection to the same view but the error msssage from ModelState will be added at the bottom of the view as validation summary is there
            }
        }




        [NonAction]
        public void LoginUser(ApplicationUserManager userManager, ApplicationUser user)
        {
            var authernicationManager = HttpContext.GetOwinContext().Authentication;
            var userIdentity = userManager.CreateIdentity(user,DefaultAuthenticationTypes.ApplicationCookie);
            authernicationManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties(),userIdentity);
        }
        [MyAuthenticationFilter]
        public ActionResult Logout()
        {
            //creating an authentication manager which is responsbile to login and out (like before):
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("index", "home");
        }

        [MyAuthenticationFilter]
        public ActionResult ChangePassword()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(RegisterViewModel rvm)
        {
            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            ApplicationUser appUser = userManager.FindById(User.Identity.GetUserId());
            var passwordHash = Crypto.HashPassword(rvm.Password);
            appUser.PasswordHash = passwordHash;
            userManager.Update(appUser);
            return RedirectToAction("UserHome", "Account");
        }
    }
}