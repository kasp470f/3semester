using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Areas.Identity.Data;
using WebApplication.Data;

[assembly: HostingStartup(typeof(WebApplication.Areas.Identity.IdentityHostingStartup))]
namespace WebApplication.Areas.Identity
{
    /// <summary>
    /// Starts the identity and dbcontext database.
    /// <para>Created by Kasper</para>
    /// </summary>
    public class IdentityHostingStartup : IHostingStartup
    {

        /// <summary>
        /// A method that would setup the configuration of the WebHost
        /// <para>Created by Kasper</para>
        /// </summary>
        /// <param name="builder">The Webhost Builder that we configure</param>
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WebApplicationContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                services.AddDefaultIdentity<AccountIdentity>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<WebApplicationContext>();
            });
        }
    }
}