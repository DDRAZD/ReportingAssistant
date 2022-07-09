using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ReportingAssistant.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
            /*see web.config -- afterwards, you will need Enable-Migrations -ContextTypeName ReportingAssistant.Identity.ApplicationDbContext -MigrationsDirectory IdentityMigrations
             
             after that, do Add-Migration -Configuration ReportingAssistant.IdentityMigrations.Configuration Initial(this is an arbitrary name)
            then
            update-database -Configuration ReportingAssistant.IdentityMigrations.Configuration
             */

        }
    }
}