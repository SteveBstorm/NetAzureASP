using GestContact.Models;
using GestContact.Tools;
using GlobalModel.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestContact.Controllers
{
    public class UserController : Controller
    {
        private IUsersService _usersService;

        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterForm form)
        {
            if(!ModelState.IsValid)
            {
                return View(form);
            }

            _usersService.Register(form.ToDal());
            return RedirectToAction("Index", "Contact");
        }
        [AdminRequired]
        public IActionResult List()
        {
            return View(_usersService.GetAll().Select(c => c.ToASP()));
        }

        [AuthRequired]
        public IActionResult Profil()
        {
            int Id = HttpContext.Session.GetUser().Id;
            return View(_usersService.GetById(Id).ToASP());
        }
    }
}
