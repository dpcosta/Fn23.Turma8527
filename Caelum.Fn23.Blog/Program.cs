using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Caelum.Fn23.Blog.Controllers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Caelum.Fn23.Blog
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //var ctrl = new PostController();
            //var view = ctrl.View("Index");
            //var posts = view.ViewData["Posts"];

            

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
