using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaBrinquedos.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaBrinquedos.Controllers
{
    public class VendaController : Controller
    {
        [HttpGet]
        public IActionResult Registrar()
        {
            CarregarDados();
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(VendaModel venda)
        {
            return View();
        }

        private void CarregarDados()
        {
            ViewBag.ListaClientes = new VendaModel().RetornarListaClientes();
            ViewBag.ListaVendedores = new VendaModel().RetornarListaVendedores();
            ViewBag.ListaProdutos = new VendaModel().RetornarListaProdutos();
        }
    }
}
