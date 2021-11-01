using CalledWebMVC.Models;
using CalledWebMVC.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CalledWebMVC.Controllers
{
    public class UsuarioController : Controller
    {


        public readonly CalledWebMvcContext _context;

        public UsuarioController(CalledWebMvcContext context)
        {
            _context = context;
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro([Bind("UsuarioId,Email,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();


                InformacaoLogin informacao = new InformacaoLogin
                {
                    UsuarioId = usuario.UsuarioId,
                    EnderecoIP = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                    Data = DateTime.Now.ToShortDateString(),
                    Horario = DateTime.Now.ToShortTimeString()
                };


                HttpContext.Session.SetInt32("UsuarioId", usuario.UsuarioId);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, usuario.Email)
                };

                var userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home");
            }
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                HttpContext.Session.Clear();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                if (_context.Usuario.Any(u => u.Email == login.Email && u.Senha == login.Senha))
                {
                    int id = _context.Usuario.Where(u => u.Email == login.Email && u.Senha == login.Senha).Select(u => u.UsuarioId).Single();

                    InformacaoLogin informacao = new InformacaoLogin
                    {
                        UsuarioId = id,
                        EnderecoIP = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                        Data = DateTime.Now.ToShortDateString(),
                        Horario = DateTime.Now.ToShortTimeString()
                    };

                    _context.Add(informacao);
                    await _context.SaveChangesAsync();

                    HttpContext.Session.SetInt32("UsuarioId", id);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, login.Email)
                    };

                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(login);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Usuario");
        }



        [AcceptVerbs("GET", "POST")]
        public IActionResult UsuarioExiste(string Email)
        {
            if (!_context.Usuario.Any(e => e.Email == Email))
            {
                return Json($"Email {Email} is already in use.");
            }

            return Json(true);
        }


        //public JsonResult UsuarioExiste(string Email)
        //{
        //    if (!_context.Usuario.Any(e => e.Email == Email))
        //        return Json(true);
        //    return Json("Email existente");
        //}
    }
}



