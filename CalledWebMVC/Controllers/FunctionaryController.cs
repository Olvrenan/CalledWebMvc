using CalledWebMVC.Models;
using CalledWebMVC.Services;
using CalledWebMVC.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;


namespace CalledWebMVC.Controllers
{
    public class FunctionaryController : Controller
    {
        private readonly FunctionaryService _FunctionaryService;

        public FunctionaryController(FunctionaryService FunctionaryService)
        {
            _FunctionaryService = FunctionaryService;
        }
        [Authorize]
        public IActionResult Index()
        {
            var list = _FunctionaryService.FindAll();
            return View(list);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(Functionary Functionary)
        {
            _FunctionaryService.Insert(Functionary);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _FunctionaryService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
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

        [Authorize]
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

        [Authorize]
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
