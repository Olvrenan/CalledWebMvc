using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CalledWebMVC.Services;
using CalledWebMVC.Models;
using CalledWebMVC.Models.ViewModels;
using CalledWebMVC.Services.Exceptions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CalledWebMVC.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskService _taskService;
        private readonly FunctionaryService _fuctionaryService;
        private readonly SprintService _sprintService;

        public TaskController(TaskService taskService, FunctionaryService fuctionaryService, SprintService sprintService)
        {
            _taskService = taskService;
            _fuctionaryService = fuctionaryService;
            _sprintService = sprintService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var list = await _taskService.FindSprint(); 
            return View(list);
        }



        public IActionResult Create()
        {

            var funcionaries = _fuctionaryService.FindAll();
            var sprints = _sprintService.FindAll();
            var viewModel = new TaskFormViewModel { Functionaries = funcionaries, Sprints = sprints };
            return View(viewModel);
        }

        [Authorize]
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


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CalledWebMVC.Models.Task task)
        {
              
            _taskService.Insert(task);
            return RedirectToAction("Details", "Sprint", new { id = task.SprintId });
        }

        [Authorize]
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
            List<Sprint> sprints = _sprintService.FindAll();
            TaskFormViewModel viewModel = new TaskFormViewModel { Task = obj, Functionaries = funcionaries, Sprints = sprints };
            return View(viewModel); 
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, CalledWebMVC.Models.Task task)
        {
            if (!ModelState.IsValid)
            {
                var funcionaries = _fuctionaryService.FindAll();
                var sprints = _sprintService.FindAll();
                var viewModel = new TaskFormViewModel { Task = task, Functionaries = funcionaries, Sprints = sprints };
                return View(viewModel);
            }
            if (id != task.Id)
            {
                return NotFound();
            }
            try
            {
                _taskService.Update(task);
                return RedirectToAction("Details", "Sprint", new { id = task.SprintId });
            }
            catch(ApplicationException e)
            {
                throw new DbConcurrencyException(e.Message);
            } 

        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var obj = _taskService.FindById(id);
            _taskService.Remove(id);
            return RedirectToAction("Details", "Sprint", new { id = obj.SprintId });
        }

    }
}
