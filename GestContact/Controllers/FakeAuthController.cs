using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestContact.Models;
using GestContact.Tools;

namespace GestContact.Controllers
{
    public class FakeAuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            User CurrentUser = new User
            {
                Id = 1,
                Email = "test@test.com",
                Password = "test1234",
                IsAdmin = true
            };

            HttpContext.Session.SetUser(CurrentUser);

            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Disconnect();
            return RedirectToAction("Index");
        }
    }
}
