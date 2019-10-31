using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caelum.Fn23.Blog.DAL;
using Caelum.Fn23.Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Caelum.Fn23.Blog.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioDAO dao;

        public UsuarioController(IUsuarioDAO dao)
        {
            this.dao = dao;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Autentica(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = dao.Todos.Where(u => u.Nome == model.Login && u.Senha == model.Password).FirstOrDefault();
                if (usuario != null)
                {
                    // colocar na sessão
                    return RedirectToAction("Index", new { Controller = "Post", Area = "Admin" });
                }
                ModelState.AddModelError("usuarioNaoEncontrado", "Usuário não encontrado");
            }
            return View("Login", model);
        }
    }
}