using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//More
using System.Diagnostics;
using IWSWebApplication.Models;
using IWSWebApplication.Controllers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IWSWebApplication.Controllers
{
    public class LoginController : Controller
    {
        //[Route("~/Home/Mainpage")]
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Message"] = "Your application Login & Sign-up Redirection page.";

            return View();
        }

        //[Route("~/Home/Mainpage")]
        [HttpPost]
        public IActionResult Index(LoginViewModel logger)
        {
            try
            {
                //string LoginEmail = logger.LoginEmail;
                //string LoginPassword = logger.LoginPassword;
                //string RegisterFirstName = logger.RegisterFirstName;
                //string RegisterLastName = logger.RegisterLastName;
                //string RegisterEmail = logger.RegisterEmail;
                //string RegisterPassword = logger.RegisterPassword;

                //ModelState.Clear();
                ViewBag.Message = "Thank you for Using our service." + "\n" + "Go ahead and use the features.";
            }

            catch (Exception ex)
            {
                ModelState.Clear();
                ViewBag.Message = $"Sorry we are facing Problem here {ex.Message}";
            }

            return View();
        }

        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
