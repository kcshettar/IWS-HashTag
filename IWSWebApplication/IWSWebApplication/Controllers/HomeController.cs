using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IWSWebApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IWSWebApplication.Controllers
{
    public class HomeController : Controller
    {
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

        [HttpGet]
        public IActionResult Contact()
        {
            //ViewData["Message"] = "Your Contact page.";

            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(client.Email, client.Name); //Email which you are getting
                    message.To.Add("kcshettar@gmail.com"); //Where mail will be sent from
                    
                    message.Subject = client.Subject;
                    message.Body = "Email From (Name): " + client.Name + "\n\n" + "Email From: " + client.Email + "\n\n" + "Message: " + client.Message;

                    MailAddress copy = new MailAddress("kcshettar1992@gmail.com");
                    message.CC.Add(copy);

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;

                    // Using to send e-mail
                    smtp.Credentials = new System.Net.NetworkCredential
                    ("kcshettar@gmail.com", "<>");

                    smtp.EnableSsl = true;

                    smtp.Send(message);

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for Contacting us." + "\n" + "A developer will contact you back withing 24 hours.";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $"Sorry we are facing Problem here {ex.Message}";
                }
            }

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}