using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApplication.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AccountIdentity class
    public class AccountIdentity : IdentityUser
    {
        [PersonalData]
        public string FullName { get; set; }

        [PersonalData]
        public string Address { get; set; }
    }
}
