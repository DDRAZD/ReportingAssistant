using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ReportingAssistant.Models
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        /// <summary>
        /// this entire class (contstructor for this class) is for methods than can manipulate the users data, i.e. handle the users already created with ApplicationUser
        /// </summary>
        /// <param name="dbContext"></param>
        public ApplicationUserStore(ReportinAssistantDBContext dbContext) : base(dbContext)
        {

        }
    }
}