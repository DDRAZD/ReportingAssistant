using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;


namespace ReportingAssistant.Models
{
   
    public class ApplicationUser : IdentityUser
    {
        //all the fields will already come from IdentityUser (use 'view definition' to see) you can add more columns and values by adding paramters here
        
       
       
       
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}