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
        // GET: SprintController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SprintController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SprintController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SprintController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
