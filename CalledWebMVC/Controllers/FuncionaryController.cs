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
    public class FuncionaryController : Controller
    {
        private readonly FuncionaryService _funcionaryService;

        public FuncionaryController(FuncionaryService funcionaryService)
        {
            _funcionaryService = funcionaryService;
        }
        public IActionResult Index()
        {
            var list = _funcionaryService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Funcionary funcionary)
        {
            _funcionaryService.Insert(funcionary);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _funcionaryService.FindById(id.Value);
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
            _funcionaryService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _funcionaryService.FindById(id.Value);
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
            var funcionary = _funcionaryService.FindById(id.Value);
            if (funcionary == null)
            {
                return NotFound();
            }

            return View(funcionary);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, Funcionary funcionary)
        {
            if (id != funcionary.Id)
            {
                return NotFound();
            }
            try
            {
                _funcionaryService.Update(funcionary);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

    }
}
