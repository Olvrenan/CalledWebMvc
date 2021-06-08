using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CalledWebMVC.Services;
using CalledWebMVC.Models;
using CalledWebMVC.Models.ViewModels;


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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Task task)
        {
           
            _taskService.Insert(task);
            return RedirectToAction(nameof(Index));
        }
    }
}
