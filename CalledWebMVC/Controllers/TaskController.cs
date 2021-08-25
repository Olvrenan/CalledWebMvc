using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CalledWebMVC.Services;
using CalledWebMVC.Models;
using CalledWebMVC.Models.ViewModels;
using CalledWebMVC.Services.Exceptions;

namespace CalledWebMVC.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskService _taskService;
        private readonly FunctionaryService _fuctionaryService;

        public TaskController(TaskService taskService, FunctionaryService fuctionaryService)
        {
            _taskService = taskService;
            _fuctionaryService = fuctionaryService;
        }

        public IActionResult Index()
        {
            var list = _taskService.FindAll(); 
            return View(list);
        }
        public IActionResult Create()
        {
            var funcionaries = _fuctionaryService.FindAll();
            var viewModel = new TaskFormViewModel { Functionaries = funcionaries };
            return View(viewModel);
        }

        public IActionResult Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var obj = _taskService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return PartialView(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Task task)
        {
           
            _taskService.Insert(task);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
  
            if (id == null)
            {
                return NotFound();
            }
            var obj = _taskService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            List<Functionary> funcionaries = _fuctionaryService.FindAll();
            TaskFormViewModel viewModel = new TaskFormViewModel { Task = obj, Functionaries = funcionaries };
            return View(viewModel); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, Task task)
        {
            if (!ModelState.IsValid)
            {
                var funcionaries = _fuctionaryService.FindAll();
                var viewModel = new TaskFormViewModel { Task = task, Functionaries = funcionaries };
                return View(viewModel);
            }
            if (id != task.Id)
            {
                return NotFound();
            }
            try
            {
                _taskService.Update(task);
                return RedirectToAction(nameof(Index));
            }
            catch(ApplicationException e)
            {
                throw new DbConcurrencyException(e.Message);
            } 

        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _taskService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return PartialView(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _taskService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
