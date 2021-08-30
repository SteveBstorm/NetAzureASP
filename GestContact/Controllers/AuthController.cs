using GestContact.Models;
using GlobalModel.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestContact.Tools;

namespace GestContact.Controllers
{
    public class AuthController : Controller
    {
        private IUsersService _service;

        public AuthController(IUsersService service)
        {
            _service = service;
        }

        public IActionResult OnGetPartial() =>

                new PartialViewResult
                {
                    ViewName = "_Login"
                };
            

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {
            User u = _service.Login(form.Email, form.Password).ToASP();
            HttpContext.Session.SetUser(u);

            return RedirectToAction("Index", "Contact");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Disconnect();
            return RedirectToAction("Index", "Contact");
        }
    }
}
