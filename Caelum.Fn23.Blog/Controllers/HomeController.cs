using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Caelum.Fn23.Blog.Models;
using Caelum.Fn23.Blog.DAL;

namespace Caelum.Fn23.Blog.Controllers
{
    public class HomeController : Controller
    {
        IPostDAO dao;

        public HomeController(IPostDAO dao)
        {
            this.dao = dao;
        }

        public IActionResult Index()
        {
            var postsPublicados = dao.Todos.Where(p => p.Publicado).ToList();
            return View(postsPublicados);
        }

        public IActionResult Busca(string termo)
        {
            var postsEncontrados = dao.Todos.Where(p => p.Publicado && p.Titulo.ToUpper().Contains(termo.ToUpper())).ToList();
            return View("Index", postsEncontrados);
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
