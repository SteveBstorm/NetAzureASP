using GestContact.Abstractions;
using GestContact.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestContact.Controllers
{
    public class ContactController : Controller
    {
        private IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact c)
        {
            if(ModelState.IsValid)
            {
                _service.AddContact(c);
                return RedirectToAction("Index");
            }

            return View(c);
            
        }

        public IActionResult Detail(int id)
        {
            return View(_service.GetContact(id));
        }

        public IActionResult Delete(int id)
        {
            _service.RemoveContact(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_service.GetContact(id));
        }

        [HttpPost]
        public IActionResult Edit(Contact c)
        {
            _service.UpdateContact(c);
            return RedirectToAction("Index");
        }
    }
}
