using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IWSWebApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IWSWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Welcome()
        {
            ViewData["Message"] = "Your application Welcome page.";
            return View();
        }

        public IActionResult Mainpage()
        {
            ViewData["Message"] = "Your application Main page.";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application Description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your Contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
