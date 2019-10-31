using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caelum.Fn23.Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Caelum.Fn23.Blog.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Autentica(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", new { Controller = "Post", Area = "Admin" });
            }
            return View("Login", model);
        }
    }
}