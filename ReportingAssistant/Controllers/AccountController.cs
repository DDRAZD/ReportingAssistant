﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportingAssistant.ViewModels;
using ReportingAssistant.DomainModels;
using Microsoft.AspNet.Identity;

using ReportingAssistant.ServiceContracts;
//using ReportingAssistant.ServiceLayer;

using System.Web.Helpers;
using ReportingAssistant.Filters;

namespace ReportingAssistant.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        IServices services;

       public AccountController(IServices servicesInjected)
        {
            //  this.services = new Services();
            this.services= servicesInjected;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(RegisterViewModel lvm)
        {
           /* var appDbContext = new ReportinAssistantDBContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            var user = userManager.Find(lvm.Username, lvm.Password);*/

            var user = services.FindUser(lvm.Username, lvm.Password);
            if (user != null)
            {
                this.LoginUser(user);
                if (services.IsAdmin(user))
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
            /* var appDbContext = new ReportinAssistantDBContext();
             var userStore = new ApplicationUserStore(appDbContext);
             var userManager = new ApplicationUserManager(userStore);*/
            //ApplicationUser appUser = userManager.FindById(User.Identity.GetUserId());
            ApplicationUser appUser = services.FindUserByID(User.Identity.GetUserId());
            return View(appUser);
        }


        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)//validation is valid of all the formats and required fields
            {
                //register
             /*   var appDbContext = new ReportinAssistantDBContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);*/
                var passwordHash = Crypto.HashPassword(rvm.Password);
                // var user = new ApplicationUser() { Email = rvm.Email, UserName = rvm.Username, PasswordHash = passwordHash, City = rvm.City, Country = rvm.Country, Address = rvm.Address, PhoneNumber = rvm.Mobile };

                //   IdentityResult result = userManager.Create(user);
                string result = services.CreateNewUser(rvm.Email, rvm.Username, passwordHash, rvm.City, rvm.Country, rvm.Address, rvm.Mobile);

                if (result!=null)
                {
                    //role
                   // userManager.AddToRole(user.Id, "User");

                    //  LoginUser(userManager, user);
                    ApplicationUser user =services.FindUserByID(result);
                    this.LoginUser(user);
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
        public void LoginUser(ApplicationUser user)
        {
            var authernicationManager = HttpContext.GetOwinContext().Authentication;
            //var userIdentity = userManager.CreateIdentity(user,DefaultAuthenticationTypes.ApplicationCookie);
            var userIdentity = services.CreateIdentity(user);
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
           /* var appDbContext = new ReportinAssistantDBContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);*/
           // ApplicationUser appUser = userManager.FindById(User.Identity.GetUserId());
            
            var passwordHash = Crypto.HashPassword(rvm.Password);
          //  appUser.PasswordHash = passwordHash;

            services.ChangePassword(passwordHash, User.Identity.GetUserId());
           // userManager.Update(appUser);
            return RedirectToAction("UserHome", "Account");
        }
    }
}