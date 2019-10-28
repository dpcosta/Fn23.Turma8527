using Microsoft.EntityFrameworkCore;
using Caelum.Fn23.Blog.Models;
using JetBrains.Annotations;

namespace Caelum.Fn23.Blog.Infra
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

    }
}
