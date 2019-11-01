using System.Linq;
using Caelum.Fn23.Blog.DAL;
using Caelum.Fn23.Blog.Filtros;
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

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("usuario");
            return RedirectToAction("Login");
        }

        [Route("autentica")]
        public IActionResult Autentica(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = dao.Todos.Where(u => u.Nome == model.Login && u.Senha == model.Password).FirstOrDefault();
                if (usuario != null)
                {
                    HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usuario));
                    return RedirectToAction("Index", new { Controller = "Post", Area = "Admin" });
                }
                ModelState.AddModelError("usuarioNaoEncontrado", "Usuário não encontrado");
            }
            return View("Login", model);
        }

        [AutorizacaoFilter]
        public IActionResult Index()
        {
            return View(dao.Todos);
        }

        [AutorizacaoFilter]
        public IActionResult Novo()
        {
            return View();
        }

        [AutorizacaoFilter]
        public IActionResult Adiciona(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    Nome = model.Login,
                    Email = model.Email,
                    Senha = model.Senha
                };
                dao.Incluir(usuario);
                return RedirectToAction("Index", new { area = "", controller = "Usuario" });
            }
            return View("Novo", model);
        }

        [AutorizacaoFilter]
        public IActionResult Excluir(Usuario model)
        {
            dao.Excluir(model);
            return RedirectToAction("Index", new { area = "", controller = "Usuario" });
        }
    }
}