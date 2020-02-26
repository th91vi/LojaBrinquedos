using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LojaBrinquedos.Models;

namespace LojaBrinquedos.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListaProdutos = new ProdutoModel().ListarTodosProdutos();
            return View();
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {

            if (id != null) // Carrega registro do Produto numa Viewbag
            {
                ViewBag.Produto = new ProdutoModel().RetornarProduto(id);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(ProdutoModel Produto)
        {
            if (ModelState.IsValid)
            {
                Produto.Gravar();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Excluir(int id)
        {
            ViewData["IdExcluir"] = id;
            return View();
        }

        public IActionResult ExcluirProduto(int id)
        {
            new ProdutoModel().ExcluirProduto(id);
            return View();
        }
    }
}