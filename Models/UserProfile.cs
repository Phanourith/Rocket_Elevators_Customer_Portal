using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace RocketElevatorsCustomerPortal.Models
{
    public class ApplicationUser : IdentityUser{

        public string Email {get; set;}
    }


}