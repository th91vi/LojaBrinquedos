using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LojaBrinquedos.Models;
using LojaBrinquedos.Uteis;
using Microsoft.AspNetCore.Http;

namespace LojaBrinquedos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Menu()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(int? id)
        {
            // Para realizar logout
            if (id != null)
            {
                if (id == 0)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", string.Empty);
                    HttpContext.Session.SetString("EmailUsuarioLogado", string.Empty);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                bool loginOK = login.ValidarLogin();
                if (loginOK)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", login.Id);
                    HttpContext.Session.SetString("EmailUsuarioLogado", login.Email);
                    return RedirectToAction("Menu", "Home");
                } else
                {
                    TempData["ErrorLogin"] = "Invalid email or password";
                }
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
