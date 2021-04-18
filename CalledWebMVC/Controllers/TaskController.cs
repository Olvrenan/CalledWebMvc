using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalledWebMVC.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
