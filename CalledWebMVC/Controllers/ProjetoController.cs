using CalledWebMVC.Models;
using CalledWebMVC.Services;
using CalledWebMVC.Services.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalledWebMVC.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly ProjetoService _projetoService;
        private readonly SprintService _sprintService;


        public ProjetoController(SprintService sprintService, ProjetoService taskService)
        {
            _sprintService = sprintService;
            _projetoService = taskService;
        }

        public async Task<ActionResult> Index()
        {
            var list = await _projetoService.FindActiveProjetos();

            return View(list);
        }
        public async Task<ActionResult> Concluidos()
        {
            var list = await _projetoService.FindDoneProjetos();



            return View(list);
        }

        public ActionResult Details(int id)
        {
            
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Sprints(int? id)
        {
            
            
            var obj = await _sprintService.FindByProjetoSprintsActive(id.Value);

            return View(obj);
        }
        public async Task<IActionResult> SprintsConcluidas(int? id)
        {

            var obj = await _sprintService.FindByProjetoSprintsDone(id.Value);

            return View(obj);
        }

        public async Task<IActionResult> Teste(int? id)
        {


            var obj = await _sprintService.FindByProjetoSprintsActive(id.Value);

            return View(obj);
        }



        // GET: ProjetoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjetoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Projeto projeto)
        {
            try
            {
                _projetoService.Insert(projeto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _projetoService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }





        // POST: ProjetoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Projeto Projeto)
        {
            if (id != Projeto.ProjetoId)
            {
                return NotFound();
            }
            try
            {
                _projetoService.Update(Projeto);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        // GET: ProjetoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

       
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
