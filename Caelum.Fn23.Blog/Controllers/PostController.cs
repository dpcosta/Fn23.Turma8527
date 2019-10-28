using Microsoft.AspNetCore.Mvc;
using Caelum.Fn23.Blog.Models;
using Caelum.Fn23.Blog.DAL;
using System;

namespace Caelum.Fn23.Blog.Controllers
{
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
            dao.Incluir(novoPost);
            return RedirectToAction("Index");
        }
        
        public ViewResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Altera(Post post)
        {
            dao.Alterar(post);
            return RedirectToAction("Index");
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
    }
}