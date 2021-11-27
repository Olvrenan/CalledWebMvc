using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalledWebMVC.Services;
using CalledWebMVC.Models;

namespace CalledWebMVC.Controllers
{
    public class GraficoController : Controller
    {
        private readonly SprintService _sprintService;
        private readonly TaskService _taskService;
        private readonly ProjetoService _projetoService;
        public readonly CalledWebMvcContext _context;


        public GraficoController(SprintService sprintService, TaskService taskService, ProjetoService projetoService)
        {
            _sprintService = sprintService;
            _taskService = taskService;
            _projetoService = projetoService;
        }
        public ActionResult Index()
        {
            var sprintsName =  _sprintService.FindAll();

            

            ViewBag.sprintsName = sprintsName;
          

            return View();
        }
      

       
    }
}
