using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;


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
        }
    }
}
