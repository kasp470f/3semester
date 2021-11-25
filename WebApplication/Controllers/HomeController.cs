using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    /// <summary>
    /// The main home controller when the user enters the web application.
    /// <para>Created by Kasper</para>
    /// </summary>
    [Authorize]
    public class HomeController : Controller
    {
        /// <summary>
        /// A action method which redirects to the Index page and allows the user to be on even if the user is not logged in.
        /// <para>Created by Kasper</para>
        /// </summary>
        /// <returns>A view of the Index page</returns>
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// A action method which redirects to the Privacy page and allows the user to be on even if the user is not logged in.
        /// <para>Created by Kasper</para>
        /// </summary>
        /// <returns>A view of the Privacy page</returns>
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// A action method which redirects to the Info page.
        /// <para>Created by Natasha</para>
        /// </summary>
        /// <returns>A view of the Info page</returns>
        public IActionResult Info()
        {
            return View();
        }

        /// <summary>
        /// <para>Created by Kasper</para>
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
