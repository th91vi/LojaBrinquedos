using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LojaBrinquedos.Models;

namespace LojaBrinquedos.Controllers
{
    public class VendedorController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListaVendedores = new VendedorModel().ListarTodosVendedores();
            return View();
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {

            if (id != null) // Carrega registro do vendedor numa Viewbag
            {
                ViewBag.Vendedor = new VendedorModel().RetornarVendedor(id);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(VendedorModel vendedor)
        {
            if (ModelState.IsValid)
            {
                vendedor.Gravar();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Excluir(int id)
        {
            ViewData["IdExcluir"] = id;
            return View();
        }

        public IActionResult ExcluirVendedor(int id)
        {
            new VendedorModel().ExcluirVendedor(id);
            return View();
        }
    }
}