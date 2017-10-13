using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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

        //StringBuilder userSignIn = new StringBuilder();
        //public List<string> UserDetails = new List<string>();

        //[Route("~/Home/Mainpage")]
        [HttpPost]
        public IActionResult Index(LoginViewModel logger)
        {
            try
            {
                //LoginViewModel loggerDetails = new LoginViewModel();

                string data1 = logger.LoginEmail;
                string data2 = logger.LoginPassword;
                string data01 = logger.RegisterFirstName;
                string data02 = logger.RegisterLastName;
                string data03 = logger.RegisterEmail;
                string data04 = logger.RegisterPassword;

                //UserDetails.Add(logger.LoginEmail);
                //userSignIn.Append(logger.LoginEmail);

                //ModelState.Clear();
                ViewBag.Message = "Thank you for Registering with us." + "\n" + "Go ahead and use the features.";
            }

            catch (Exception ex)
            {
                ModelState.Clear();
                ViewBag.Message = $"Sorry we are facing Problem here {ex.Message}";
            }
            //string userList = UserDetails.ToString()

            return View();
        }

        public IActionResult Mainpage()
        {
            ViewData["Message"] = "Your application Main page.";

            return View();
        }

        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
