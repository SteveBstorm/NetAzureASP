using GestContact.Abstractions;
using GestContact.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestContact.Tools;

using DAL = GlobalModel.Interface;

namespace GestContact.Controllers
{
    public class ContactController : Controller
    {
        private DAL.IContactService _service;

        public ContactController(DAL.IContactService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetAll().Select(c => c.ToASP()));
        }
        [AdminRequired]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact c)
        {
            if(ModelState.IsValid)
            {
                _service.Create(c.ToDal());
                return RedirectToAction("Index");
            }

            return View(c);
            
        }
        [AuthRequired]
        public IActionResult Detail(int id)
        {
            return View(_service.GetById(id).ToASP());
        }
        [AdminRequired]

        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        [AdminRequired]
        public IActionResult Edit(int id)
        {
            return View(_service.GetById(id).ToASP());
        }

        [HttpPost]
        public IActionResult Edit(Contact c)
        {
            _service.Update(c.ToDal());
            return RedirectToAction("Index");
        }
    }
}
