using Microsoft.AspNetCore.Mvc;
using Caelum.Fn23.Blog.Models;
using Caelum.Fn23.Blog.DAL;
using System;
using System.Linq;
using Caelum.Fn23.Blog.Filtros;

namespace Caelum.Fn23.Blog.Controllers
{
    [Area("Admin")]
    [AutorizacaoFilter]
    public class PostController : Controller
    {
        IPostDAO dao;

        public PostController(IPostDAO dao)
        {
            this.dao = dao;
        }

        public IActionResult Index()
        {
            return View(dao.Todos);
        }

        [HttpPost]
        public IActionResult Adiciona(Post novoPost)
        {
            if (ModelState.IsValid)
            {
                dao.Incluir(novoPost);
                return RedirectToAction("Index");
            }
            return View("Novo", novoPost);
        }

        public ViewResult Novo()
        {
            return View(new Post());
        }

        [HttpPost]
        public IActionResult Altera(Post post)
        {
            if (ModelState.IsValid)
            {
                dao.Alterar(post);
                return RedirectToAction("Index");
            }
            return View("Editar", post);
        }

        public IActionResult Editar(int id)
        {
            var post = dao.BuscarPorId(id);
            return View(post);
        }

        public IActionResult Publicar(int id)
        {
            var post = dao.BuscarPorId(id);
            post.DataPublicacao = DateTime.Now;
            post.Publicado = true;
            dao.Alterar(post);
            return RedirectToAction("Index");
        }

        public IActionResult Excluir(Post post)
        {
            dao.Excluir(post);
            return RedirectToAction("Index");
        }

        public IActionResult CategoriaAutocomplete(string termoDigitado)
        {
            return Ok(dao.Todos
                .Select(p => p.Categoria)
                .Distinct()
                .Where(c => c.ToUpper().Contains(termoDigitado.ToUpper())));
        }
    }
}