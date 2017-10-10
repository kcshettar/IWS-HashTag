using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Options;
using IWSWebApplication.Models;
using IWSWebApplication.Services;

namespace IWSWebApplication.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Users/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(IFormCollection formData, Users usermodel)
        {
            try
            {
                MongoDBService context = new MongoDBService();

                var builder = Builders<Users>.Filter;
                var filter = builder.Eq("Username", usermodel.Username) |
                builder.Eq("Email", usermodel.Email);
                var result = context.User.Find(filter);

                var count = result.Count();

                if (count == 0)
                {
                    context.User.InsertOne(usermodel);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["Message"] = "Username or Email already exists!";
                    return View();
                }

            }
            catch (Exception ex)
            {
                //throw new Exception("Error: ", ex);
                ViewData["Message"] = ex;
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}