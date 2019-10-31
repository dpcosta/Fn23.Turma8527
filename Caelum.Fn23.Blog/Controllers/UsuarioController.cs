using System.Linq;
using Caelum.Fn23.Blog.DAL;
using Caelum.Fn23.Blog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("usuario");
            return RedirectToAction("Login");
        }

        public IActionResult Autentica(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = dao.Todos.Where(u => u.Nome == model.Login && u.Senha == model.Password).FirstOrDefault();
                if (usuario != null)
                {
                    // colocar na sessão
                    HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuario));
                    return RedirectToAction("Index", new { Controller = "Post", Area = "Admin" });
                }
                ModelState.AddModelError("usuarioNaoEncontrado", "Usuário não encontrado");
            }
            return View("Login", model);
        }
    }
}