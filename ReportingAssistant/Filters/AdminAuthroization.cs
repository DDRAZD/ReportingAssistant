using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace ReportingAssistant.Filters
{
    public class AdminAuthroization : FilterAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// this checks the user permissions - i.e. after the user logged in -> but as we will change filtercontext.Result to unathorized it will again throw you to login page if we put this at on the right controller
        /// </summary>
        /// <param name="filterContext"></param>
        
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.HttpContext.User.IsInRole("Admin")==false)
            {
                filterContext.Result =new HttpUnauthorizedResult();//toggle the filter context to unauthorized, similar to the authetnication user outcome
            }
            
        }
    }
}