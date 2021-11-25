using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication.Areas.Identity.Data;

namespace WebApplication.Data
{
    /// <summary>
    /// Bridge between entity class and database
    /// <para>Created by Kasper</para>
    /// </summary>
    public class WebApplicationContext : IdentityDbContext<AccountIdentity>
    {
        /// <summary>
        /// Constructor of Context
        /// <para>Created by Kasper</para>
        /// </summary>
        public WebApplicationContext(DbContextOptions<WebApplicationContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Configures the schema needed for the identity framework.
        /// <para>Created by Kasper</para>
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
