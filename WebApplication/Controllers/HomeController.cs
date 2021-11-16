﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Profile()
        {

            return View();
        }

        [HttpPost]
        public IActionResult GetDetails()
        {
            User umodel = new User();
            umodel.Name = HttpContext.Request.Form["Name"].ToString();
            umodel.Mail = HttpContext.Request.Form["Mail"].ToString();
            umodel.Adress = HttpContext.Request.Form["Adress"].ToString();
            umodel.Phone = Convert.ToInt32(HttpContext.Request.Form["Phone"]);
            int result = umodel.SaveDetails();
            if (result > 0)
            {
                return Content("Data Saved Successfully");
            }
            else
            {
                return View();
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
