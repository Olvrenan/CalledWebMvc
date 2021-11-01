using CalledWebMVC.Models;
using CalledWebMVC.Services;
using CalledWebMVC.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CalledWebMVC.Controllers
{
    public class SprintController : Controller
    {

        private readonly SprintService _sprintService;
        private readonly TaskService _taskService;

        
        public SprintController(SprintService sprintService, TaskService taskService)
        {
            _sprintService = sprintService;
            _taskService = taskService;
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {

            var list = await _sprintService.FindActiveSprints();
            return View(list);
        }

        [Authorize]
        public async Task<ActionResult> Concluidas()
        {

            var list = await _sprintService.FindDoneSprints();
            return View(list);
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {

            var obj = await _taskService.FindBySprint(id.Value);

            return View(obj);
        }

        [Authorize]
        public ActionResult Create()
        {

            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sprint sprint)
        {

            _sprintService.Insert(sprint);
            return RedirectToAction(nameof(Index));

        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Sprint = _sprintService.FindById(id.Value);
            if (Sprint == null)
            {
                return NotFound();
            }

            return View(Sprint);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, Sprint Sprint)
        {
            if (id != Sprint.Id)
            {
                return NotFound();
            }
            try
            {
                _sprintService.Update(Sprint);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Authorize]
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
