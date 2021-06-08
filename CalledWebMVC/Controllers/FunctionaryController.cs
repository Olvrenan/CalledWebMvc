using CalledWebMVC.Models;
using CalledWebMVC.Services;
using CalledWebMVC.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalledWebMVC.Controllers
{
    public class FunctionaryController : Controller
    {
        private readonly FunctionaryService _FunctionaryService;

        public FunctionaryController(FunctionaryService FunctionaryService)
        {
            _FunctionaryService = FunctionaryService;
        }
        public IActionResult Index()
        {
            var list = _FunctionaryService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Functionary Functionary)
        {
            _FunctionaryService.Insert(Functionary);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _FunctionaryService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _FunctionaryService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _FunctionaryService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Functionary = _FunctionaryService.FindById(id.Value);
            if (Functionary == null)
            {
                return NotFound();
            }

            return View(Functionary);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, Functionary Functionary)
        {
            if (id != Functionary.Id)
            {
                return NotFound();
            }
            try
            {
                _FunctionaryService.Update(Functionary);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

    }
}
