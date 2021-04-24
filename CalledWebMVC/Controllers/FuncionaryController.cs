using CalledWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalledWebMVC.Controllers
{
    public class FuncionaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
