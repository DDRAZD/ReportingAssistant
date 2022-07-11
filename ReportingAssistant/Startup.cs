﻿using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using ReportingAssistant.Identity;


[assembly: OwinStartup(typeof(ReportingAssistant.Startup))]

namespace ReportingAssistant
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCookieAuthentication(new CookieAuthenticationOptions() { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath=new PathString("/Account/Login") });

            //this gives us use of cookies, and login path says if the use is not logged in yet (no cookie) send them to login


            //creating two roles - user and admin; it will be created in the first time the application runs

            this.CreateRolesAndUsers(); //calling to create the roles by the method defined below

            
        }
        /// <summary>
        /// a method that we will call when the application starts to create the roles for the first time
        /// </summary>
        public void CreateRolesAndUsers()
        {
            //we need to work with the role manager and with the user manager

            //default role manager:
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>()); //this is for the table of role
            var appDbContext = new ApplicationDbContext();//this is how to talk to the DB for identity
            var appUserStore = new ApplicationUserStore(appDbContext);//this is for the table of users

            //creating an ability to manage roles and users:
            var userManager = new ApplicationUserManager(appUserStore);


            //create admin role
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            //creating at least one admin user if the role is empty and there are no users in it

            if(!(userManager.FindByName("admin")==null))
            {
                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";
                string userPassword = "123";
               //trying to create the user (the first admin):
                var chkUser = userManager.Create(user,userPassword);

                if(chkUser.Succeeded)
                {
                    //if the user was created, we can now add it to the admin role (tying the roles table to the user table in this case)
                    userManager.AddToRole(user.Id, "Admin");
                }

            }

            //creating the regular user role
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }
            //no need to create default user as we will just register them (different than admin)

        }
    }
}
