using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ReportingAssistant.Models
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        /// <summary>
        /// a constructor that invokes the parent by using "base" key word; it gets the entire the user 'store'
        /// </summary>
        /// <param name="store"></param>
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {

        }
    }
}