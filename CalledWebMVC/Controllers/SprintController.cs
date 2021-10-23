using CalledWebMVC.Models;
using CalledWebMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalledWebMVC.Controllers
{
    public class SprintController : Controller
    {

        private readonly SprintService _sprintService;
        private readonly TaskService _taskService;

        public SprintController( SprintService sprintService, TaskService taskService)
        {
            _sprintService = sprintService;
            _taskService = taskService;
        }

        // GET: SprintController
        public async Task<ActionResult> Index()
        {
            
            var list = await  _sprintService.FindActiveSprints();
            return View(list);
        }

        // GET: SprintController/Details/5

        public async Task<IActionResult> Details(int? id)
        {

            var obj =  await _taskService.FindBySprint(id.Value);

            return View(obj);
        }

        // GET: SprintController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: SprintController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sprint sprint)
        {

            _sprintService.Insert(sprint);
            return RedirectToAction(nameof(Index));

        }

        // GET: SprintController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SprintController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SprintController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SprintController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
