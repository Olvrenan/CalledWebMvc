using CalledWebMVC.Models;
using CalledWebMVC.Services;
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
        public IActionResult Create(Funcionary funcionary)
        {
            return View();
        }
    }
}
