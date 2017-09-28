using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using IWSWebApplication.Models;
using static IWSWebApplication.Startup;
using static IWSWebApplication.Startup.MongoContext;

namespace IWSWebApplication.Controllers
{
    public class UsersController : Controller
    {

        MongoContext _dbcontext;

        public UsersController(IOptions<Settings> settings)
        {
            _dbcontext = new MongoContext(settings);
        }

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
        public ActionResult Register(IFormCollection collection)
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
                var document = 

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