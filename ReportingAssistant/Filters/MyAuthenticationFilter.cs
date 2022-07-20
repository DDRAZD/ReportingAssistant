using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;


namespace ReportingAssistant.Filters
{
    /// <summary>
    /// these filters need to then be applied to the appropriate controllers so MVC knows to run them
    /// </summary>
    public class MyAuthenticationFilter : FilterAttribute, IAuthenticationFilter
    {
        /// <summary>
        /// this filter is invoked automatically when the user sends requests to any method
        /// </summary>
        /// <param name="filterContext"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //filter context exists before every method as MVC runs it automtically (hence the intheritance from FIlterATtribute)
            if(filterContext.HttpContext.User.Identity.IsAuthenticated==false)
            {
                filterContext.Result = new HttpUnauthorizedResult();//toggle the filter context to unauthorized
            }
        }

        /// <summary>
        /// after the above OnAuthenication method excutes, the OnAuthetnicationChallenge executes and can have custom logic
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //kept empty on purpose as no specific need for it right now
        }
    }
}